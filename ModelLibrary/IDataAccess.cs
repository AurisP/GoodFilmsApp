using ModelLibrary.Models;
using System;
using System.Collections.Generic;

namespace ModelLibrary
{
    public interface IDataAccess // Funtions shall be synchronous and possibly throw exceptions
    {
        MetadataModel requestMetadata();
        List<FilmModel> requestFilms(int offset, int amount, QueryModel query);
        List<DirectorModel> requestDirectors(int offset, int amount, QueryModel query);
        List<GenreModel> requestGenres(int offset, int amount, QueryModel query);
        List<LanguageModel> requestLanguages(int offset, int amount, QueryModel query);
        List<StudioModel> requestStudios(int offset, int amount, QueryModel query);
        void setFilmWatched(int filmId, bool watched);
        void setFilmScheduled(int filmId, DateTime date);
        void setFilmRating(int filmId, int stars);
        void setComment(int filmId, string comment, string commentDate);
        CommentModel requestComment(int filmId);
        void removeComment(int commentId);

    }
}
