using ModelLibrary.Models;
using System.Collections.Generic;

namespace ModelLibrary
{
    public class QueryModel
    {
        public string strSearch;
        public int? intMinLenSec;
        public int? intMaxLenSec;
        public int? intReleaseYear;
        public List<int> listStudios;
        public List<int> listGenres;
        public List<int> listDirectors;
        public List<int> listAgeRatings;
        public List<int> listLanguages;
        public List<int> listExcludeIds;
        public List<int> listIncludeIds;
        public bool boolRandom;
        public bool boolExcludeWatched;
        public QueryModel()
        {
            strSearch = null;
            intMinLenSec = null;
            intMaxLenSec = null;
            intReleaseYear = null;
            listStudios = new List<int>();
            listGenres = new List<int>();
            listDirectors = new List<int>();
            listAgeRatings = new List<int>();
            listLanguages = new List<int>();
            listIncludeIds = new List<int>();
            boolRandom = false;
            boolExcludeWatched = false;
        }
    }
}
