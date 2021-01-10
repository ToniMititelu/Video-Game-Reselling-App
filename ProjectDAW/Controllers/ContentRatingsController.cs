using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Models;

namespace ProjectDAW.Controllers
{
    [Authorize]
    public class ContentRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContentRatings
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContentRating.ToListAsync());
        }

        // GET: ContentRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentRating = await _context.ContentRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentRating == null)
            {
                return NotFound();
            }

            return View(contentRating);
        }

        // GET: ContentRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContentRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,MinimumAge")] ContentRating contentRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contentRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contentRating);
        }

        // GET: ContentRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentRating = await _context.ContentRating.FindAsync(id);
            if (contentRating == null)
            {
                return NotFound();
            }
            return View(contentRating);
        }

        // POST: ContentRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,MinimumAge")] ContentRating contentRating)
        {
            if (id != contentRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contentRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentRatingExists(contentRating.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contentRating);
        }

        // GET: ContentRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contentRating = await _context.ContentRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contentRating == null)
            {
                return NotFound();
            }

            return View(contentRating);
        }

        // POST: ContentRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contentRating = await _context.ContentRating.FindAsync(id);
            _context.ContentRating.Remove(contentRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentRatingExists(int id)
        {
            return _context.ContentRating.Any(e => e.Id == id);
        }
    }
}
