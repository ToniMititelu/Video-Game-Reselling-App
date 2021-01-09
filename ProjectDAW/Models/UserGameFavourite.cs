using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class UserGameFavourite
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
