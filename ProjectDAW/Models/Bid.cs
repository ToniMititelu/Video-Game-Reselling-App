using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public int ListingId { get; set; }
        [ForeignKey("ListingId")]
        public Listing Listing { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public decimal BidAmount { get; set; }
    }
}
