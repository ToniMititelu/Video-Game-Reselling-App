using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Models;

namespace ProjectDAW.Controllers
{
    public class GameGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GameGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GameGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GameGenre.Include(g => g.Game).Include(g => g.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GameGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre
                .Include(g => g.Game)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            return View(gameGenre);
        }

        // GET: GameGenres/Create
        public IActionResult Create()
        {
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title");
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Title");
            return View();
        }

        // POST: GameGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,GenreId")] GameGenre gameGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title", gameGenre.GameId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Title", gameGenre.GenreId);
            return View(gameGenre);
        }

        // GET: GameGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre.FindAsync(id);
            if (gameGenre == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title", gameGenre.GameId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Title", gameGenre.GenreId);
            return View(gameGenre);
        }

        // POST: GameGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,GenreId")] GameGenre gameGenre)
        {
            if (id != gameGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameGenreExists(gameGenre.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title", gameGenre.GameId);
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Title", gameGenre.GenreId);
            return View(gameGenre);
        }

        // GET: GameGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameGenre = await _context.GameGenre
                .Include(g => g.Game)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameGenre == null)
            {
                return NotFound();
            }

            return View(gameGenre);
        }

        // POST: GameGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameGenre = await _context.GameGenre.FindAsync(id);
            _context.GameGenre.Remove(gameGenre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameGenreExists(int id)
        {
            return _context.GameGenre.Any(e => e.Id == id);
        }
    }
}
