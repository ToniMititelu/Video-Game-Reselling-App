using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(25)]
        public string Nickname { get; set; }

        public List<Listing> Listings { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
