using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace ControllerLibrary
{
    public class CController : IController
    {

        private CCallback<List<FilmModel>> filmsRxCb;
        private CCallback<List<DirectorModel>> directorsRxCb;
        private CCallback<List<GenreModel>> genresRxCb;
        private CCallback<List<StudioModel>> studiosRxCb;
        private CCallback<List<ScheduledFilmModel>> scheduledFilmsRxCb;
        private CCallback<string> errorRxCb;
        private int globalId;
        public CController(
            Action<int, List<FilmModel>> filmsRxCb,
            Action<int, List<DirectorModel>> directorsRxCb,
            Action<int, List<GenreModel>> genresRxCb,
            Action<int, List<StudioModel>> studiosRxCb,
            Action<int, List<ScheduledFilmModel>> scheduledFilmsRxCb,
            Action<int, string> errorRxCb)
        {
            this.filmsRxCb = new CCallback<List<FilmModel>>(filmsRxCb);
            this.directorsRxCb = new CCallback<List<DirectorModel>>(directorsRxCb);
            this.genresRxCb = new CCallback<List<GenreModel>>(genresRxCb);
            this.studiosRxCb = new CCallback<List<StudioModel>>(studiosRxCb);
            this.scheduledFilmsRxCb = new CCallback<List<ScheduledFilmModel>>(scheduledFilmsRxCb);
            this.errorRxCb = new CCallback<string>(errorRxCb);
            globalId = 0;
        }
        public int addComment(FilmModel mode, string name, string comment)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        public int requestFilms(int page, int count)
        {
            filmsRxCb.call(globalId, () => CDataAccess.loadFilm(page, count));
            return globalId++;
        }

        public int rmComment(FilmModel mode, int id)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        public int setFilmScheduled(FilmModel mode, DateTime date)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        public int setFilmWatched(FilmModel model, bool watched)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        public int setUserRating(FilmModel mode, int stars)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        int IController.addFilter(CFilter filter)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }

        int IController.clearFilter(CFilter filter)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }
    }
}
