using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class LanguageFilmModel
    {
        public int Id { get; set; }

        public LanguageModel Language { get; set; }

        public FilmModel Film { get; set; }
    }
}
