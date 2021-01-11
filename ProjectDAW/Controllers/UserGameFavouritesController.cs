using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Models;

namespace ProjectDAW.Controllers
{
    public class UserGameFavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserGameFavouritesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserGameFavourites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserGameFavourite.Include(u => u.Game).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserGameFavourites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGameFavourite = await _context.UserGameFavourite
                .Include(u => u.Game)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGameFavourite == null)
            {
                return NotFound();
            }

            return View(userGameFavourite);
        }

        // GET: UserGameFavourites/Create
        public IActionResult Create(int gameId)
        {
            ViewData["GameId"] = gameId;
            return View();
        }

        // POST: UserGameFavourites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId")] UserGameFavourite userGameFavourite)
        {
            var gameId = userGameFavourite.GameId;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var game = await _context.Game.FirstOrDefaultAsync(m => m.Id == gameId);

            if (game == null || user == null)
            {
                return NotFound();
            }

            userGameFavourite.User = user;
            userGameFavourite.Game = game;

            if (ModelState.IsValid)
            {
                _context.Add(userGameFavourite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine($"user = {user.Id}");
            Console.WriteLine($"game = {game.Id}");
            return View(userGameFavourite);
        }

        // GET: UserGameFavourites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGameFavourite = await _context.UserGameFavourite.FindAsync(id);
            if (userGameFavourite == null)
            {
                return NotFound();
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title", userGameFavourite.GameId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userGameFavourite.UserId);
            return View(userGameFavourite);
        }

        // POST: UserGameFavourites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,UserId")] UserGameFavourite userGameFavourite)
        {
            if (id != userGameFavourite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGameFavourite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGameFavouriteExists(userGameFavourite.Id))
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
            ViewData["GameId"] = new SelectList(_context.Game, "Id", "Title", userGameFavourite.GameId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userGameFavourite.UserId);
            return View(userGameFavourite);
        }

        // GET: UserGameFavourites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGameFavourite = await _context.UserGameFavourite
                .Include(u => u.Game)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userGameFavourite == null)
            {
                return NotFound();
            }

            return View(userGameFavourite);
        }

        // POST: UserGameFavourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userGameFavourite = await _context.UserGameFavourite.FindAsync(id);
            _context.UserGameFavourite.Remove(userGameFavourite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserGameFavouriteExists(int id)
        {
            return _context.UserGameFavourite.Any(e => e.Id == id);
        }
    }
}
