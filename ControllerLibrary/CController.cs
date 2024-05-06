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
    // Controller interface defining asynchronous film-related actions.
    public class CController : IController
    {
        private IDataAccess access;

        // Constructor initializes the data access layer.
        public CController()
        {
            access = new CDataAccess();
        }

        // Method to run an action asynchronously using a background worker.
        private static void runAsync(Action cb)
        {
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += (sender, args) => ((Action)args.Argument)();
            w.RunWorkerAsync(cb);
        }

        // Asynchronously sets the 'watched' property of a film.
        // Arguments:
        //   - model: The film model to update.
        //   - watched: Boolean value indicating if the film is watched.
        //   - on_success: Action to invoke upon successful execution.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.setFilmWatched(FilmModel model, bool watched, Action on_success, Action<string> on_error)
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

        // Asynchronously sets the scheduled date for a film.
        // Arguments:
        //   - model: The film model to update.
        //   - date: The new scheduled date for the film.
        //   - on_success: Action to invoke upon successful execution.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.setFilmScheduled(FilmModel model, DateTime date, Action on_success, Action<string> on_error)
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

        // Asynchronously sets the rating for a film.
        // Arguments:
        //   - model: The film model to update.
        //   - stars: The rating value to set for the film.
        //   - on_success: Action to invoke upon successful execution.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.setFilmRating(FilmModel model, int stars, Action on_success, Action<string> on_error)
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

        // Asynchronously adds a comment to a film.
        // Arguments:
        //   - model: The film model to which the comment will be added.
        //   - comment: The comment text to be added.
        //   - on_success: Action to invoke upon successful execution.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.addComment(FilmModel model, string comment, Action on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // If the comment is empty, invoke success callback and return.
                    if (string.IsNullOrEmpty(comment))
                    {
                        on_success?.Invoke();
                        return;
                    }

                    // Truncate the comment if it exceeds 4000 characters.
                    if (comment.Length > 4000)
                    {
                        comment = comment.Substring(0, 4000);
                    }

                    // Generate comment date in the format "yyyy-MM-dd HH:mm:ss".
                    string commentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // Set the comment for the film using data access layer.
                    access.setComment(model.Id, comment, commentDate);

                    // Invoke success callback.
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while adding comment: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests the comment associated with a film.
        // Arguments:
        //   - model: The film model for which the comment is requested.
        //   - on_success: Action to invoke upon successful execution, providing the retrieved comment.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestComment(FilmModel model, Action<CommentModel> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Retrieve the comment associated with the film using data access layer.
                    var comment = access.requestComment(model.Id);

                    // Invoke success callback with the retrieved comment.
                    on_success?.Invoke(comment);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting comment: " + ex.ToString());
                }
            });
        }

        // Asynchronously removes a comment associated with a film.
        // Arguments:
        //   - model: The film model from which the comment will be removed.
        //   - comment_id: The ID of the comment to be removed.
        //   - on_success: Action to invoke upon successful execution.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.removeComment(FilmModel model, int comment_id, Action on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Remove the comment using data access layer.
                    access.removeComment(comment_id);

                    // Invoke success callback.
                    on_success?.Invoke();
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while removing comment: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests films based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering films.
        //   - offset: The offset for pagination.
        //   - count: The number of films to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of films.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestFilms(CFilter filter, int offset, int count, Action<List<FilmModel>> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Request films based on the provided filter and pagination parameters.
                    var films = access.requestFilms(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved films.
                    on_success?.Invoke(films);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting films: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests directors based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering directors.
        //   - offset: The offset for pagination.
        //   - count: The number of directors to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of directors.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestDirectors(CFilter filter, int offset, int count, Action<List<DirectorModel>> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Request directors based on the provided filter and pagination parameters.
                    var directors = access.requestDirectors(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved directors.
                    on_success?.Invoke(directors);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting directors: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests genres based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering genres.
        //   - offset: The offset for pagination.
        //   - count: The number of genres to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of genres.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestGenres(CFilter filter, int offset, int count, Action<List<GenreModel>> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Request genres based on the provided filter and pagination parameters.
                    var genres = access.requestGenres(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved genres.
                    on_success?.Invoke(genres);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting genres: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests languages based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering languages.
        //   - offset: The offset for pagination.
        //   - count: The number of languages to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of languages.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestLanguages(CFilter filter, int offset, int count, Action<List<LanguageModel>> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Request languages based on the provided filter and pagination parameters.
                    var languages = access.requestLanguages(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved languages.
                    on_success?.Invoke(languages);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting languages: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests studios based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering studios.
        //   - offset: The offset for pagination.
        //   - count: The number of studios to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of studios.
        //   - on_error: Action to invoke if an error occurs, providing an error message.
        void IController.requestStudios(CFilter filter, int offset, int count, Action<List<StudioModel>> on_success, Action<string> on_error)
        {
            runAsync(() =>
            {
                try
                {
                    // Request studios based on the provided filter and pagination parameters.
                    var studios = access.requestStudios(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved studios.
                    on_success?.Invoke(studios);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting studios: " + ex.ToString());
                }
            });
        }

        // Asynchronously requests age ratings based on the provided filter.
        // Arguments:
        //   - filter: The filter object containing criteria for filtering age ratings.
        //   - offset: The offset for pagination.
        //   - count: The number of age ratings to retrieve.
        //   - on_success: Action to invoke upon successful execution, providing the list of age ratings.
        //   - on_error: Action to invoke if an error occurs, providing an error message. (optional)
        void IController.requestAgeRatings(CFilter filter, int offset, int count, Action<List<AgeRatingModel>> on_success, Action<string> on_error = null)
        {
            runAsync(() =>
            {
                try
                {
                    // Request age ratings based on the provided filter and pagination parameters.
                    var ageRatings = access.requestAgeRatings(offset, count, filter.toQuery());

                    // Invoke success callback with the retrieved age ratings.
                    on_success?.Invoke(ageRatings);
                }
                catch (Exception ex)
                {
                    // Invoke error callback if an exception occurs.
                    on_error?.Invoke("Error while requesting age ratings: " + ex.ToString());
                }
            });
        }

    }
}
