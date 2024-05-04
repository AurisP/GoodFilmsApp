using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using ModelLibrary;

namespace ControllerLibrary
{
    public class CFilter
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

        public CFilter()
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
            listExcludeIds = new List<int>();
            listIncludeIds = new List<int>();
            boolRandom = false;
            boolExcludeWatched = false;
        }

        public QueryModel toQuery()
        {
            return new QueryModel {
                strSearch = this.strSearch,
                intMinLenSec = this.intMinLenSec,
                intMaxLenSec = this.intMaxLenSec,
                intReleaseYear = this.intReleaseYear,
                listStudios = this.listStudios,
                listGenres = this.listGenres,
                listDirectors = this.listDirectors,
                listAgeRatings = this.listAgeRatings,
                listLanguages = this.listLanguages,
                listExcludeIds = this.listExcludeIds,
                listIncludeIds = this.listIncludeIds,
                boolRandom = this.boolRandom,
                boolExcludeWatched = this.boolExcludeWatched
            };
        }
    }
}
