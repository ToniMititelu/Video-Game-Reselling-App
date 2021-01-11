using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Data;
using ProjectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Controllers
{
    [Authorize(Policy = "writepolicy")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ActionResult> Index()
        {
            var applicationDbContext = await _context.Users.ToListAsync();
            ViewBag.UsersList = applicationDbContext;
            return View();
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            var roles = await _userManager.GetRolesAsync(user);

            ViewBag.user = user;
            ViewBag.roles = roles;

            Console.WriteLine($"roles={roles[0]}");

            return View(user);
        }
    }
}
