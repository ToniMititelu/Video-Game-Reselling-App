using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string Title { get; set; }

        public int? ContentRatingId { get; set; }

        [ForeignKey("ContentRatingId")]
        public ContentRating? ContentRating { get; set; }
    }
}
