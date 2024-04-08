using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class FilmModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration_Sec { get; set; }

        public int Release_Year { get; set; }

        public AgeRatingModel Age_Rating { get; set; }

        public string Trailer_Url { get; set; }

        public string Poster_Url { get; set; }

        public int User_Rating { get; set; }

        public int Watched { get; set; }

        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public List<DirectorFilmModel> DirectorFilms { get; set; } = new List<DirectorFilmModel>();

        public List<GenreFilmModel> GenreFilms { get; set; } = new List<GenreFilmModel>();

        public List<StudioFilmModel> StudioFilms { get; set; } = new List<StudioFilmModel>();

        public List<ScheduledFilmModel> ScheduledFilms { get; set; } = new List<ScheduledFilmModel>();
    }

}
