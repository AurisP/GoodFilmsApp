using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ControllerLibrary
{
    public class CController : IController
    {
        private IDataAccess access;
        private CFilter filter;
        private CCallback<List<FilmModel>> filmsRxCb;
        private CCallback<CFilmsMetadataCache> metadataRxCb;
        private CCallback<List<ScheduledFilmModel>> scheduledFilmsRxCb;
        private CCallback<CommentModel> commentRxCb;
        private CCallback<string> errorRxCb;
        private int globalId;
        public CController(
            Action<int, List<FilmModel>> filmsRxCb,
            Action<int, CFilmsMetadataCache> metadataRxCb,
            Action<int, List<ScheduledFilmModel>> scheduledFilmsRxCb,
            Action<int, CommentModel> commentRxCb,
            Action<int, string> errorRxCb)
        {
            this.access = new CDataAccess();
            this.filmsRxCb = new CCallback<List<FilmModel>>(filmsRxCb);
            this.metadataRxCb = new CCallback<CFilmsMetadataCache>(metadataRxCb);
            this.scheduledFilmsRxCb = new CCallback<List<ScheduledFilmModel>>(scheduledFilmsRxCb);
            this.commentRxCb = new CCallback<CommentModel>(commentRxCb);
            this.errorRxCb = new CCallback<string>(errorRxCb);
            globalId = 0;
        }
        void IController.addFilter(CFilter filter)
        {
            this.filter = filter;
        }
        void IController.clearFilters()
        {
            this.filter = null;
        }
        int IController.addComment(FilmModel model, string comment)
        {
            int film_id = model.Id;
            string commentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            errorRxCb.call(globalId, () => access.updateComment(film_id, comment, commentDate));
            return globalId++;
        }
        int IController.requestFilms(int page, int count, QueryModel queryModel, bool isFirstLoad)
        {
            //QueryModel queryModel = new QueryModel();
            if (this.filter != null)
            {
                queryModel.Query = filter.strSearch;
                queryModel.Random = filter.boolRandom;
            }
            filmsRxCb.call(globalId, () => access.requestFilms(page, count, queryModel, isFirstLoad));
            return globalId++;
        }

        int IController.requestComments(FilmModel model)
        {
            int film_id = model.Id;
            commentRxCb.call(globalId, () => {
                var data = access.requestComments(film_id);
                return data;
            });
            return globalId++;
        }
        int IController.rmComment(FilmModel model, int id)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }
        int IController.setFilmScheduled(FilmModel model, DateTime date)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }
        int IController.setFilmWatched(FilmModel model, bool watched)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }
        int IController.setUserRating(FilmModel mode, int stars)
        {
            errorRxCb.call(globalId, () => "This functionality is unimplemented");
            return globalId++;
        }
        int IController.requestMeta()
        {
            metadataRxCb.call(globalId, () => {
                var data = access.requestMetadata();
                return new CFilmsMetadataCache(data.directors, data.genres, data.studios, data.languages, data.ageRatings);
            });
            return globalId++;
        }
    }
}
