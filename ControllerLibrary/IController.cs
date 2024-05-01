using ModelLibrary;
using System;
using System.Collections.Generic;

namespace ControllerLibrary
{
    using FilmModel = ModelLibrary.Models.FilmModel;
    public interface IController
    {
        void addFilter(CFilter filter);
        void clearFilters();
        int setFilmWatched(FilmModel model, bool watched);
        int setFilmScheduled(FilmModel mode, DateTime date);
        int setUserRating(FilmModel mode, int stars);
        int addComment(FilmModel mode, string comment);
        int requestComments(FilmModel model);
        int rmComment(FilmModel mode, int id);
        int requestFilms(int offset, int count, Action<List<FilmModel>> cb = null);
        int requestMeta();
    }
}
