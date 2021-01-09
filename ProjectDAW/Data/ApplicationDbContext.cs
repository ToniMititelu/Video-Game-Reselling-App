using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDAW.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ContentRating> ContentRating { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<GameGenre> GameGenre { get; set; }
        public DbSet<UserGameFavourite> UserGameFavourite { get; set; }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}
