using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class StudioFilmModel
    {
        public StudioModel Studio { get; set; }
        public FilmModel Film { get; set; }
    }
}
