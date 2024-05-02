using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace ControllerLibrary
{
    public class CController : IController
    {
        private IDataAccess access;
        public CController()
        {
            access = new CDataAccess();
        }
        private static void runAsync(Action cb)
        {
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += (sender, args) => ((Action)args.Argument)();
            w.RunWorkerAsync(cb);
        }

        void IController.setFilmWatched(FilmModel model, bool watched, Action on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    access.setFilmWatched(model.Id, watched);
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while setting 'watched' property: " + ex.ToString());
                }
            });
        }
        void IController.setFilmScheduled(FilmModel model, DateTime date, Action on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    access.setFilmScheduled(model.Id, date);
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while setting schedule: " + ex.ToString());
                }
            });
        }
        void IController.setFilmRating(FilmModel model, int stars, Action on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    access.setFilmRating(model.Id, stars);
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while setting rating: " + ex.ToString());
                }
            });
        }
        void IController.addComment(FilmModel model, string comment, Action on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    if (comment == null && comment == "")
                    {
                        on_success?.Invoke();
                        return;
                    }
                    string commentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    access.setComment(model.Id, comment, commentDate);
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while adding comment: " + ex.ToString());
                }
            });
        }
        void IController.requestComment(FilmModel model, Action<CommentModel> on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    var comment = access.requestComment(model.Id);
                    on_success?.Invoke(comment);
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while requesting comment: " + ex.ToString());
                }
            });
        }
        void IController.removeComment(FilmModel model, int comment_id, Action on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    access.removeComment(comment_id);
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while removing comment: " + ex.ToString());
                }
            });
        }
        void IController.requestFilms(CFilter filter, int offset, int count, Action<List<FilmModel>> on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    var films = access.requestFilms(offset, count, filter.toQuery());
                    on_success?.Invoke(films);
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while requesting films: " + ex.ToString());
                }
            });
        }
        void IController.requestMeta(Action<CFilmsMetadataCache> on_success, Action<String> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    var meta = access.requestMetadata();
                    on_success?.Invoke(new CFilmsMetadataCache(meta.directors, meta.genres, meta.studios, meta.languages, meta.ageRatings));
                }
                catch (Exception ex)
                {
                    on_error?.Invoke("Error while requesting metadata: " + ex.ToString());
                }
            });
        }
    }
}
