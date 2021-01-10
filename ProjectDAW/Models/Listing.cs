using Microsoft.AspNetCore.Identity;
using ProjectDAW.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        [Required]
        [MinLength(50), MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MinLength(5), MaxLength(100)]
        public string Title { get; set; }

        [ListingValidator]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpiresAt { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }
        public decimal? BuyNowPrice { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
