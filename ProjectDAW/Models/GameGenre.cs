using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
