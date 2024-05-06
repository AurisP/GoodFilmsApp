using ModelLibrary.Models;
using System;
using System.Collections.Generic;

namespace ControllerLibrary
{
    // Interface defining methods for controlling film-related operations.
    public interface IController
    {
        // Sets the 'watched' status of a film.
        void setFilmWatched(FilmModel model, bool watched, Action on_success, Action<string> on_error = null);

        // Sets the scheduled date of a film.
        void setFilmScheduled(FilmModel model, DateTime date, Action on_success, Action<string> on_error = null);

        // Sets the user rating of a film.
        void setFilmRating(FilmModel model, int stars, Action on_success, Action<string> on_error = null);

        // Adds a comment to a film.
        void addComment(FilmModel model, string comment, Action on_success, Action<string> on_error = null);

        // Requests the comment associated with a film.
        void requestComment(FilmModel model, Action<CommentModel> on_success, Action<string> on_error = null);

        // Removes a comment associated with a film.
        void removeComment(FilmModel model, int comment_id, Action on_success, Action<string> on_error = null);

        // Requests a list of films based on a filter, offset, and count.
        void requestFilms(CFilter filter, int offset, int count, Action<List<FilmModel>> on_success, Action<string> on_error = null);

        // Requests a list of directors based on a filter, offset, and count.
        void requestDirectors(CFilter filter, int offset, int count, Action<List<DirectorModel>> on_success, Action<string> on_error = null);

        // Requests a list of genres based on a filter, offset, and count.
        void requestGenres(CFilter filter, int offset, int count, Action<List<GenreModel>> on_success, Action<string> on_error = null);

        // Requests a list of languages based on a filter, offset, and count.
        void requestLanguages(CFilter filter, int offset, int count, Action<List<LanguageModel>> on_success, Action<string> on_error = null);

        // Requests a list of studios based on a filter, offset, and count.
        void requestStudios(CFilter filter, int offset, int count, Action<List<StudioModel>> on_success, Action<string> on_error = null);

        // Requests a list of age ratings based on a filter, offset, and count.
        void requestAgeRatings(CFilter filter, int offset, int count, Action<List<AgeRatingModel>> on_success, Action<string> on_error = null);
    }

}
