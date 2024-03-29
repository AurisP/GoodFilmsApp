using System;

namespace ControllerLibrary
{
    using FilmModel = ModelLibrary.Models.FilmModel;
    internal interface IController
    {
        int addFilter(CFilter filter);
        int clearFilter(CFilter filter);
        int setFilmWatched(FilmModel model, bool watched);
        int setFilmScheduled(FilmModel mode, DateTime date);
        int setUserRating(FilmModel mode, int stars);
        int addComment(FilmModel mode, string name, string comment);
        int rmComment(FilmModel mode, int id);
        int requestFilms(int page, int count);
    }
}
