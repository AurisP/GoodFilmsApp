using ModelLibrary.Models;
using System.Collections.Generic;

namespace ModelLibrary
{
    public class QueryModel
    {
        public QueryModel()
        {
            Studios = new List<StudioModel>();
            Genres = new List<GenreModel>();
            Directors = new List<DirectorModel>();
            AgeRatings = new List<AgeRatingModel>();
        }
        public int MaxDuration { get; set; }
        public int MinDuration { get; set; }
        public List<StudioModel> Studios { get; set; }
        public List<GenreModel> Genres { get; set; }
        public List<DirectorModel> Directors { get; set; }
        public List<AgeRatingModel> AgeRatings { get; set; }
        public int ReleaseYear { get; set; }


    }
}
