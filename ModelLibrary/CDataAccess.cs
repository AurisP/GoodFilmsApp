using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.ComponentModel.Design;
using System.Collections;
using static Dapper.SqlBuilder;
using System.Data.Entity.Infrastructure;
using System.Runtime.CompilerServices;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace ModelLibrary
{

    public class CDataAccess : IDataAccess
    {
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private IDbConnection cnn;

        public CDataAccess()
        {
            this.cnn = new SQLiteConnection(LoadConnectionString());
            this.cnn.Open();
        }

        MetadataModel IDataAccess.requestMetadata()
        {
            return new MetadataModel( // TODO: any way to do this in 1 request?
                cnn.Query<DirectorModel>((new SqlBuilder()).AddTemplate("SELECT * FROM directors").RawSql).ToList(),
                cnn.Query<GenreModel>((new SqlBuilder()).AddTemplate("SELECT * FROM genres").RawSql).ToList(),
                cnn.Query<StudioModel>((new SqlBuilder()).AddTemplate("SELECT * FROM studios").RawSql).ToList(),
                cnn.Query<LanguageModel>((new SqlBuilder()).AddTemplate("SELECT * FROM languages").RawSql).ToList(),
                cnn.Query<AgeRatingModel>((new SqlBuilder()).AddTemplate("SELECT * FROM age_ratings").RawSql).ToList()
            );
        }

        List<FilmModel> IDataAccess.requestFilms(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.strSearch != null)
            {
                builder = builder.Where("title LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            if (query.intReleaseYear != null)
            {
                builder = builder.Where("release_year = @Year", new { Year = query.intReleaseYear });
            }
            if (query.intMaxLenSec != null)
            {
                builder = builder.Where("duration_sec <= @Seconds", new { Seconds = Convert.ToDouble(query.intMaxLenSec) * 3600 });
            }
            if (query.intMinLenSec != null)
            {
                builder = builder.Where("duration_sec >= @Seconds", new { Seconds = Convert.ToDouble(query.intMinLenSec) * 3600 });
            }
            if (query.listAgeRatings != null && query.listAgeRatings.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var rating in query.listAgeRatings)
                {
                    queries.Add("age_rating_id = " + rating.ToString());
                }
                builder = builder.Where(String.Join(" OR ", queries.ToArray()));
            }
            /*if (query.Genres != null && query.Genres.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var rating in queryModel.AgeRatings)
                {
                    queries.Add("age_rating_id = " + rating.Id.ToString());
                }
                builder = builder.Where(String.Join(" OR ", queries.ToArray()));
            }*/
            Template template;
            if (query.boolRandom)
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ ORDER BY RANDOM() LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            else if (query.strSearch != null)
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            else
            {
                template = builder.AddTemplate("SELECT * FROM films ORDER BY title LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            Console.WriteLine("SQL: " + template.RawSql);
            Console.WriteLine("release year " + query.intReleaseYear.ToString());
            var output = cnn.Query<FilmModel>(template.RawSql, template.Parameters);
           /* if (queryModel.ReleaseYear != 0)
                output = output.Where(x => x.Release_Year == queryModel.ReleaseYear);



            double second = 3600;
            if (queryModel.MaxDuration != 0)
                output = output.Where(x => x.Duration_Sec / second <= Convert.ToDouble(queryModel.MaxDuration));
            if (queryModel.MinDuration != 0)
                output = output.Where(x => x.Duration_Sec / second >= Convert.ToDouble(queryModel.MinDuration));

            if (queryModel.AgeRatings.Count != 0)
                output = output.Where(x => queryModel.AgeRatings.Select(u => u.Id).ToList().Contains(x.age_rating_id));


            if (queryModel.Directors.Count != 0)
            {
                var allDirectorFilms = LoadDirectorFilms();


                var selectedDirectorIds = queryModel.Directors.Select(u => u.Id).ToList();

                var chosenDirectorFilms = allDirectorFilms
                .Where(x => selectedDirectorIds.Contains(x.director_id))
                .ToList();

                output = output.Where(x => chosenDirectorFilms.Select(y => y.film_id).Contains(x.Id));
            }


            if (queryModel.Genres.Count != 0)
            {
                var allGenresFilms = LoadGenresFilms();


                var selectedGenresIds = queryModel.Genres.Select(u => u.Id).ToList();

                var chosenGenreFilms = allGenresFilms
                .Where(x => selectedGenresIds.Contains(x.genre_id))
                .ToList();

                output = output.Where(x => chosenGenreFilms.Select(y => y.film_id).Contains(x.Id));
            }


            if (queryModel.Studios.Count != 0)
            {
                var allStudioFilms = LoadStudioFilms();


                var selectedStudioIds = queryModel.Studios.Select(u => u.Id).ToList();

                var chosenStudioFilms = allStudioFilms
                .Where(x => selectedStudioIds.Contains(x.studio_id))
                .ToList();

                output = output.Where(x => chosenStudioFilms.Select(y => y.film_id).Contains(x.Id));
            }


            if (queryModel.Languages.Count != 0)
            {
                var allLanguagesFilms = LoadLanguagesFilms();

                var selectedLanguageIds = queryModel.Languages.Select(u => u.Id).ToList();

                var chosenLanguageFilms = allLanguagesFilms
                .Where(x => selectedLanguageIds.Contains(x.language_id))
                .ToList();

                output = output.Where(x => chosenLanguageFilms.Select(y => y.film_id).Contains(x.Id));
            }*/

            return output.ToList();
        }

        void IDataAccess.setFilmWatched(int filmId, bool watched)
        {
            SqlBuilder builder = new SqlBuilder();
            builder = builder.Where("id = @whereId", new { whereId = filmId });
            Template template = builder.AddTemplate("UPDATE films SET watched = @setWatched /**where**/", new { setWatched = watched} );
            int rows = cnn.Execute(template.RawSql, template.Parameters);
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }
        void IDataAccess.setFilmScheduled(int filmId, DateTime date)
        {
            SqlBuilder builder = new SqlBuilder();
            Template template = builder.AddTemplate("INSERT INTO soon_to_watch_films (film_id, watch_date) VALUES (@setFilmId, @setDate)", new { setFilmId = filmId, setDate = date });
            int rows = cnn.Execute(template.RawSql, template.Parameters);
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }
        void IDataAccess.setFilmRating(int filmId, int stars)
        {
            SqlBuilder builder = new SqlBuilder();
            builder = builder.Where("id = @whereId", new { whereId = filmId });
            Template template = builder.AddTemplate("UPDATE films SET user_rating = @setRating /**where**/", new { setRating = stars });
            int rows = cnn.Execute(template.RawSql, template.Parameters);
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }
        void IDataAccess.setComment(int filmId, string comment, string commentDate) //TODO: add also update with insert
        {
            SqlBuilder builder = new SqlBuilder();
            Template template;
            var args = new { whereFilmId = filmId, CommentText = comment, CommentDate = commentDate };

            var existingComment = cnn.QueryFirstOrDefault<CommentModel>("SELECT * FROM comments WHERE film_id = @whereFilmId", args);

            if (existingComment != null)
            {
                template = builder.AddTemplate("UPDATE comments SET comment_text = @CommentText, comment_date = @CommentDate WHERE film_id = @FilmId", args);
            }
            else
            {
                template = builder.AddTemplate("INSERT INTO comments (film_id, comment_text, comment_date) VALUES (@FilmId, @CommentText, @CommentDate)", args);
            }

            var rowsAffected = cnn.Execute(template.RawSql, template.Parameters);
            if (rowsAffected > 0)
            {
            //    return String.Empty;
            } 
            else
            {
            //    return "Error";
            }   
        }

        CommentModel IDataAccess.requestComment(int filmId)
        {
            SqlBuilder builder = new SqlBuilder();
            Template template;
            template = builder.AddTemplate("SELECT * FROM comments WHERE film_id = @whereFilmId", new { whereFilmId = filmId });
            var output = cnn.QueryFirstOrDefault<CommentModel>(template.RawSql, template.Parameters);
            return output;
        }
        void IDataAccess.removeComment(int commentId)
        {
            SqlBuilder builder = new SqlBuilder();
            Template template;
            template = builder.AddTemplate("DELETE FROM comments WHERE id = @whereCommentId", new { whereCommentId = commentId });
            int rows = cnn.Execute(template.RawSql, template.Parameters);
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }
    }
}
