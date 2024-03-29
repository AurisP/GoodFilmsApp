using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class CDirectorFilmModel
    {
        public DirectorModel Director { get; set; }
        public FilmModel Film { get; set; }
    }
}
