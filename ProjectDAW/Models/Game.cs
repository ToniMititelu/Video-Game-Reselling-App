using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(10), MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int ContentRatingId { get; set; }
        [ForeignKey("ContentRatingId")]
        public ContentRating ContentRating { get; set; }

        public List<Listing> Listings { get; set; }

        public Image Image { get; set; }
    }
}
