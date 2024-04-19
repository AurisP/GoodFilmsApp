using System;

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
        int addComment(FilmModel mode, string name, string comment);
        int rmComment(FilmModel mode, int id);
        int requestFilms(int page, int count);
        int requestMeta();
    }
}
