using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class ContentRating
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Content Rating")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Minimum Age")]
        public int MinimumAge { get; set; }
    }
}
