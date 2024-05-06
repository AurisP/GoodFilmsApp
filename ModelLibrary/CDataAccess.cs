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
        List<FilmModel> IDataAccess.requestFilms(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.strSearch != null)
            {
                builder = builder.Where("films.title LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            if (query.intReleaseYear != null)
            {
                builder = builder.Where("films.release_year = @Year", new { Year = query.intReleaseYear });
            }
            if (query.intMaxLenSec != null)
            {
                builder = builder.Where("films.duration_sec <= @Seconds", new { Seconds = query.intMaxLenSec });
            }
            if (query.intMinLenSec != null)
            {
                builder = builder.Where("films.duration_sec >= @Seconds", new { Seconds = query.intMinLenSec });
            }
            if (query.listAgeRatings != null && query.listAgeRatings.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var rating in query.listAgeRatings)
                {
                    queries.Add("films.age_rating_id = " + rating.ToString());
                }
                builder = builder.Where("(" + String.Join(" OR ", queries.ToArray()) + ")");
            }
            if (query.listGenres != null && query.listGenres.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var genre in query.listGenres)
                {
                    queries.Add("genres_films.genre_id=" + genre.ToString());
                }
                builder = builder.InnerJoin("genres_films ON genres_films.film_id = films.id AND (" + String.Join(" OR ", queries.ToArray()) + ")");
            }
            if (query.listDirectors != null && query.listDirectors.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var director in query.listDirectors)
                {
                    queries.Add("directors_films.director_id=" + director.ToString());
                }
                builder = builder.InnerJoin("directors_films ON directors_films.film_id = films.id AND (" + String.Join(" OR ", queries.ToArray()) + ")");
            }
            if (query.listLanguages != null && query.listLanguages.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var language in query.listLanguages)
                {
                    queries.Add("languages_films.language_id=" + language.ToString());
                }
                builder = builder.InnerJoin("languages_films ON languages_films.film_id = films.id AND (" + String.Join(" OR ", queries.ToArray()) + ")");
            }
            if (query.listStudios != null && query.listStudios.Count > 0)
            {
                List<string> queries = new List<string>();
                foreach (var studio in query.listStudios)
                {
                    queries.Add("studios_films.studio_id=" + studio.ToString());
                }
                builder = builder.InnerJoin("studios_films ON studios_films.film_id = films.id AND (" + String.Join(" OR ", queries.ToArray()) + ")");
            }
            if (query.boolOnlyScheduled)
            {
                builder = builder.InnerJoin("soon_to_watch_films ON soon_to_watch_films.film_id = films.id");
                builder = builder.OrderBy("soon_to_watch_films.watch_date");
            }
            if (query.boolRandom || query.strSearch == null || query.strSearch == "")
            {
                builder = builder.OrderBy("RANDOM()");
            }
            else
            {
                builder = builder.OrderBy("films.title");
            }
            Template template;
            template = builder.AddTemplate("SELECT films.* FROM films /**innerjoin**/ /**where**/ GROUP BY films.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            Console.WriteLine(template.RawSql);
            var output = cnn.Query<FilmModel>(template.RawSql, template.Parameters);
            return output.ToList();
        }
        List<DirectorModel> IDataAccess.requestDirectors(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("directors.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("directors.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }
            if (query.strSearch != null)
            {
                builder = builder.Where("directors.name LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            builder = builder.OrderBy("directors.name");
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("directors.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }
            Template template;
            template = builder.AddTemplate("SELECT directors.* FROM directors /**innerjoin**/ /**where**/ GROUP BY directors.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            var output = cnn.Query<DirectorModel>(template.RawSql, template.Parameters);
            return output.ToList();
        }
        List<GenreModel> IDataAccess.requestGenres(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("genres.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("genres.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }
            if (query.strSearch != null)
            {
                builder = builder.Where("genres.genre LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            builder = builder.OrderBy("genres.genre");
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("genres.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }
            Template template;
            template = builder.AddTemplate("SELECT genres.* FROM genres /**innerjoin**/ /**where**/ GROUP BY genres.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            var output = cnn.Query<GenreModel>(template.RawSql, template.Parameters);
            return output.ToList();
        }
        List<LanguageModel> IDataAccess.requestLanguages(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("languages.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("languages.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }
            if (query.strSearch != null)
            {
                builder = builder.Where("languages.language LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            builder = builder.OrderBy("languages.language");
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("languages.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }
            Template template;
            template = builder.AddTemplate("SELECT languages.* FROM languages /**innerjoin**/ /**where**/ GROUP BY languages.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            var output = cnn.Query<LanguageModel>(template.RawSql, template.Parameters);
            return output.ToList();
        }
        List<StudioModel> IDataAccess.requestStudios(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("studios.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("studios.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }
            if (query.strSearch != null)
            {
                builder = builder.Where("studios.studio LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            builder = builder.OrderBy("studios.studio");
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("studios.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }
            Template template;
            template = builder.AddTemplate("SELECT studios.* FROM studios /**innerjoin**/ /**where**/ GROUP BY studios.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            var output = cnn.Query<StudioModel>(template.RawSql, template.Parameters);
            return output.ToList();
        }
        List<AgeRatingModel> IDataAccess.requestAgeRatings(int offset, int amount, QueryModel query)
        {
            SqlBuilder builder = new SqlBuilder();
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("age_ratings.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("age_ratings.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }
            if (query.strSearch != null)
            {
                builder = builder.Where("age_ratings.rating LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }
            builder = builder.OrderBy("age_ratings.rating");
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("age_ratings.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }
            Template template;
            template = builder.AddTemplate("SELECT age_ratings.* FROM age_ratings /**innerjoin**/ /**where**/ GROUP BY age_ratings.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            var output = cnn.Query<AgeRatingModel>(template.RawSql, template.Parameters);
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
        void IDataAccess.setComment(int filmId, string comment, string commentDate)
        {
            SqlBuilder builder = new SqlBuilder();
            Template template = builder.AddTemplate("REPLACE INTO comments (id, film_id, comment_text, comment_date) VALUES ((SELECT id FROM comments WHERE film_id=@FilmId), @FilmId, @CommentText, @CommentDate)", 
                new {CommentText = comment, CommentDate = commentDate, FilmId = filmId});
            int rows = cnn.Execute(template.RawSql, template.Parameters);
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
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
