using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class GenreFilmModel
    {
        public FilmModel Film { get; set; } 
        public GenreModel Genre { get; set; } 
    }
}
