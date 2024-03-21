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
        public string Title { get; set; }

        public string Description { get; set; }

        public int DurationSec { get; set; }

        public int ReleaseYear { get; set; }

        public AgeRatingModel AgeRating { get; set; }

        public string TrailerUrl { get; set; }

        public string PosterUrl { get; set; }

        public StudioModel Studio { get; set; }

        public DirectorModel Director { get; set; }

        public int UserRating { get; set; }

        public GenreModel Genre { get; set; }

        public int Watched { get; set; }

        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();

        public List<DirectorFilmModel> DirectorFilms { get; set; } = new List<DirectorFilmModel>();

        public List<GenreFilmModel> GenreFilms { get; set; } = new List<GenreFilmModel>();

        public List<StudioFilmModel> StudioFilms { get; set; } = new List<StudioFilmModel>();

        public List<ScheduledFilmModel> ScheduledFilms { get; set; } = new List<ScheduledFilmModel>();
    }

}
