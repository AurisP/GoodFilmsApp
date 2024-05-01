using System;

namespace ControllerLibrary
{
    public class CFilter
    {
        public string strSearch;
        public string strGenre;
        public string strAgeRating;
        public int? intMinLenSec;
        public int? intMaxLenSec;
        public int? intReleaseYear;
        public string strStudio;
        public string strDirector;
        public bool boolRandom;

        public CFilter()
        {
            strSearch = null;
            strGenre = null;
            strAgeRating = null;
            intMinLenSec = null;
            intMaxLenSec = null;
            intReleaseYear = null;
            strStudio = null;
            strDirector = null;
            boolRandom = false;
        }
    }
}
