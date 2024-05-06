using ModelLibrary.Models;
using System;
using System.Collections.Generic;

namespace ModelLibrary
{
    // Interface for synchronous data access operations related to films.
    public interface IDataAccess
    {
        // Retrieves a list of films based on specified criteria.
        List<FilmModel> requestFilms(int offset, int amount, QueryModel query);

        // Retrieves a list of directors based on specified criteria.
        List<DirectorModel> requestDirectors(int offset, int amount, QueryModel query);

        // Retrieves a list of genres based on specified criteria.
        List<GenreModel> requestGenres(int offset, int amount, QueryModel query);

        // Retrieves a list of languages based on specified criteria.
        List<LanguageModel> requestLanguages(int offset, int amount, QueryModel query);

        // Retrieves a list of studios based on specified criteria.
        List<StudioModel> requestStudios(int offset, int amount, QueryModel query);

        // Retrieves a list of age ratings based on specified criteria.
        List<AgeRatingModel> requestAgeRatings(int offset, int amount, QueryModel query);

        // Marks a film as watched or unwatched.
        void setFilmWatched(int filmId, bool watched);

        // Sets the scheduled date for watching a film.
        void setFilmScheduled(int filmId, DateTime date);

        // Sets the user rating for a film.
        void setFilmRating(int filmId, int stars);

        // Sets a comment for a film at a given date.
        void setComment(int filmId, string comment, string commentDate);

        // Retrieves the comment associated with a specific film.
        CommentModel requestComment(int filmId);

        // Removes a comment from the database.
        void removeComment(int commentId);
    }

}
