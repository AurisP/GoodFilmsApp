using System;

namespace ControllerLibrary
{
    public class CFilter
    {
        string strSearch;
        string strGenre;
        string strAgeRating;
        int? intMinLenSec;
        int? intMaxLenSec;
        string strStudio;
        string strDirector;
        bool? boolRandom;

        CFilter()
        {
            strSearch = null;
            strGenre = null;
            strAgeRating = null;
            intMinLenSec = null;
            intMaxLenSec = null;
            strStudio = null;
            strDirector = null;
            boolRandom = null;
        }
    }
}
