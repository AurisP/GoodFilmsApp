using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFilmsApp
{
    public class CStudioData
    {
        public int Id { get; set; }
        public string Studio { get; set; }
        public bool Chosen { get; set; }
    }
    public class CGenreData
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public bool Chosen { get; set; }
    }
    public class CDirectorData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Chosen { get; set; }
    }
    public class CAgeRatingData
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        public bool Chosen { get; set; }
    }
    public class CLanguageData
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public bool Chosen { get; set; }
    }
}
