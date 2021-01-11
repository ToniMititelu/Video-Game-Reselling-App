using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Models;

namespace ProjectDAW.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GamesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Game
                .Include(g => g.Listings)
                .Include(g => g.ContentRating);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Favourite games
        [Authorize]
        public async Task<IActionResult> Mine()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var gameFavs = await _context.UserGameFavourite.Where(g => g.User == user).ToListAsync();

            var myFavs = new List<int>();

            foreach(var g in gameFavs) 
            {
                Console.WriteLine(g.GameId);
                myFavs.Add(g.GameId);
            }

            var applicationDbContext = _context.Game
                .Include(g => g.Listings)
                .Include(g => g.ContentRating)
                .Where(g => myFavs.Contains(g.Id));
                
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(game => game.Listings)
                .ThenInclude(listing => listing.User)
                .Include(game => game.Image)
                .Include(g => g.ContentRating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Games/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ContentRatingId"] = new SelectList(_context.ContentRating, "Id", "Title");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Description,ContentRatingId,Image")] Game game)
        {
            Image image = new Image();
            image.Base64Encoded = game.Image.Base64Encoded;
            image.Game = game;
            image.GameId = game.Id;

            game.Image = image;

            if (ModelState.IsValid)
            {
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContentRatingId"] = new SelectList(_context.ContentRating, "Id", "Title", game.ContentRatingId);
            return View(game);
        }

        // GET: Games/Edit/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["ContentRatingId"] = new SelectList(_context.ContentRating, "Id", "Title", game.ContentRatingId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Description,ContentRatingId")] Game game)
        {
            if (id != game.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
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
            ViewData["ContentRatingId"] = new SelectList(_context.ContentRating, "Id", "Title", game.ContentRatingId);
            return View(game);
        }

        // GET: Games/Delete/5
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.ContentRating)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
