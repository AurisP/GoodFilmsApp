using ModelLibrary.Models;
using System;
using System.Collections.Generic;

namespace ControllerLibrary
{
    public interface IController
    {
        void setFilmWatched(FilmModel model, bool watched, Action on_success, Action<String> on_error = null);
        void setFilmScheduled(FilmModel model, DateTime date, Action on_success, Action<String> on_error = null);
        void setFilmRating(FilmModel model, int stars, Action on_success, Action<String> on_error = null);
        void addComment(FilmModel model, string comment, Action on_success, Action<String> on_error = null);
        void requestComment(FilmModel model, Action<CommentModel> on_success, Action<String> on_error = null);
        void removeComment(FilmModel model, int comment_id, Action on_success, Action<String> on_error = null);
        void requestFilms(CFilter filter, int offset, int count, Action<List<FilmModel>> on_success, Action<String> on_error = null);
        void requestMeta(Action<CFilmsMetadataCache> on_success, Action<String> on_error = null);
    }
}
