using System.Collections.Generic;

namespace ModelLibrary.Models
{
    public class FilmModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration_Sec { get; set; }

        public int Release_Year { get; set; }

        public int age_rating_id { get; set; }

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
