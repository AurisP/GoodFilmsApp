using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class DirectorFilmModel
    {
        public DirectorModel Director { get; set; } = null!;
        public FilmModel Film { get; set; } = null!;
    }
}
