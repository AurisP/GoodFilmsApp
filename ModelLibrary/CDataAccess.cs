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

        // Method to load a connection string from the configuration file.
        // Arguments:
        //   - id (optional): The ID of the connection string to load. Default is "Default".
        // Returns:
        //   - string: The connection string corresponding to the provided ID.
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        // Private field to hold the database connection.
        private IDbConnection cnn;

        // Constructor for CDataAccess class.
        // Initializes a new SQLiteConnection and opens the connection.
        public CDataAccess()
        {
            this.cnn = new SQLiteConnection(LoadConnectionString());
            this.cnn.Open();
        }

        // Method for requesting films based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, release year, etc.
        // Returns:
        //   - List<FilmModel>: A list of FilmModel objects that match the given criteria.
        List<FilmModel> IDataAccess.requestFilms(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append WHERE clauses based on the provided query parameters.

            // Search string condition.
            if (query.strSearch != null)
            {
                builder = builder.Where("films.title LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Release year condition.
            if (query.intReleaseYear != null)
            {
                builder = builder.Where("films.release_year = @Year", new { Year = query.intReleaseYear });
            }

            // Maximum duration condition.
            if (query.intMaxLenSec != null)
            {
                builder = builder.Where("films.duration_sec <= @Seconds1", new { Seconds1 = query.intMaxLenSec });
            }

            // Minimum duration condition.
            if (query.intMinLenSec != null)
            {
                builder = builder.Where("films.duration_sec >= @Seconds2", new { Seconds2 = query.intMinLenSec });
            }

            // Age ratings condition.
            if (query.listAgeRatings != null && query.listAgeRatings.Count > 0)
            {
                // Build a list of OR conditions for age ratings.
                List<string> queries = new List<string>();
                foreach (var rating in query.listAgeRatings)
                {
                    queries.Add("films.age_rating_id = " + rating.ToString());
                }
                // Combine OR conditions into a single WHERE clause.
                builder = builder.Where("(" + String.Join(" OR ", queries.ToArray()) + ")");
            }

            // Inner join with genres condition.
            if (query.listGenres != null && query.listGenres.Count > 0)
            {
                // Build a list of OR conditions for genre IDs.
                List<string> queries = new List<string>();
                foreach (var genre in query.listGenres)
                {
                    queries.Add("genres_films.genre_id=" + genre.ToString());
                }
                // Combine OR conditions into a single INNER JOIN clause.
                builder = builder.InnerJoin("genres_films ON genres_films.film_id = films.id AND (" + String.Join(" OR ", queries.ToArray()) + ")");
            }

            // Inner join with soon_to_watch_films condition.
            if (query.boolOnlyScheduled)
            {
                builder = builder.InnerJoin("soon_to_watch_films ON soon_to_watch_films.film_id = films.id");
                builder = builder.OrderBy("soon_to_watch_films.watch_date");
            }

            // Order by random or title.
            if (query.boolRandom || query.strSearch == null || query.strSearch == "")
            {
                builder = builder.OrderBy("RANDOM()");
            }
            else
            {
                builder = builder.OrderBy("films.title");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT films.* FROM films /**innerjoin**/ /**where**/ GROUP BY films.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Output the generated SQL query for debugging purposes.
            Console.WriteLine(template.RawSql);

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<FilmModel>(template.RawSql, template.Parameters);

            // Return the list of FilmModel objects.
            return output.ToList();
        }


        // Method to request directors based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, include/exclude IDs, etc.
        // Returns:
        //   - List<DirectorModel>: A list of DirectorModel objects that match the given criteria.
        List<DirectorModel> IDataAccess.requestDirectors(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append ORDER BY clauses for included IDs.
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("directors.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("directors.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }

            // Append WHERE clause for search string.
            if (query.strSearch != null)
            {
                builder = builder.Where("directors.name LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Order by director name by default.
            builder = builder.OrderBy("directors.name");

            // Append WHERE clause for excluded IDs.
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("directors.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT directors.* FROM directors /**innerjoin**/ /**where**/ GROUP BY directors.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<DirectorModel>(template.RawSql, template.Parameters);

            // Return the list of DirectorModel objects.
            return output.ToList();
        }


        // Method to request genres based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, include/exclude IDs, etc.
        // Returns:
        //   - List<GenreModel>: A list of GenreModel objects that match the given criteria.
        List<GenreModel> IDataAccess.requestGenres(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append ORDER BY clauses for included IDs.
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("genres.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("genres.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }

            // Append WHERE clause for search string.
            if (query.strSearch != null)
            {
                builder = builder.Where("genres.genre LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Order by genre name by default.
            builder = builder.OrderBy("genres.genre");

            // Append WHERE clause for excluded IDs.
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("genres.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT genres.* FROM genres /**innerjoin**/ /**where**/ GROUP BY genres.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<GenreModel>(template.RawSql, template.Parameters);

            // Return the list of GenreModel objects.
            return output.ToList();
        }


        // Method to request languages based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, include/exclude IDs, etc.
        // Returns:
        //   - List<LanguageModel>: A list of LanguageModel objects that match the given criteria.
        List<LanguageModel> IDataAccess.requestLanguages(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append ORDER BY clauses for included IDs.
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("languages.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("languages.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }

            // Append WHERE clause for search string.
            if (query.strSearch != null)
            {
                builder = builder.Where("languages.language LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Order by language name by default.
            builder = builder.OrderBy("languages.language");

            // Append WHERE clause for excluded IDs.
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("languages.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT languages.* FROM languages /**innerjoin**/ /**where**/ GROUP BY languages.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<LanguageModel>(template.RawSql, template.Parameters);

            // Return the list of LanguageModel objects.
            return output.ToList();
        }
    

        // Method to request studios based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, include/exclude IDs, etc.
        // Returns:
        //   - List<StudioModel>: A list of StudioModel objects that match the given criteria.
        List<StudioModel> IDataAccess.requestStudios(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append ORDER BY clauses for included IDs.
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("studios.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("studios.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }

            // Append WHERE clause for search string.
            if (query.strSearch != null)
            {
                builder = builder.Where("studios.studio LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Order by studio name by default.
            builder = builder.OrderBy("studios.studio");

            // Append WHERE clause for excluded IDs.
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("studios.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT studios.* FROM studios /**innerjoin**/ /**where**/ GROUP BY studios.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<StudioModel>(template.RawSql, template.Parameters);

            // Return the list of StudioModel objects.
            return output.ToList();
        }

        // Method to request age ratings based on various criteria.
        // Arguments:
        //   - offset: The number of records to skip before starting to return results.
        //   - amount: The maximum number of records to return.
        //   - query: An object containing query parameters such as search string, include/exclude IDs, etc.
        // Returns:
        //   - List<AgeRatingModel>: A list of AgeRatingModel objects that match the given criteria.
        List<AgeRatingModel> IDataAccess.requestAgeRatings(int offset, int amount, QueryModel query)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append ORDER BY clauses for included IDs.
            if (query.listIncludeIds != null && query.listIncludeIds.Count > 0)
            {
                builder = builder.OrderBy("age_ratings.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ") DESC");
                builder = builder.OrWhere("age_ratings.id IN (" + String.Join(",", query.listIncludeIds.ToArray()) + ")");
            }

            // Append WHERE clause for search string.
            if (query.strSearch != null)
            {
                builder = builder.Where("age_ratings.rating LIKE @Query", new { Query = "%" + query.strSearch + "%" });
            }

            // Order by age rating name by default.
            builder = builder.OrderBy("age_ratings.rating");

            // Append WHERE clause for excluded IDs.
            if (query.listExcludeIds != null && query.listExcludeIds.Count > 0)
            {
                builder = builder.Where("age_ratings.id NOT IN (" + String.Join(",", query.listExcludeIds.ToArray()) + ")");
            }

            // Generate SQL query template.
            Template template;
            template = builder.AddTemplate("SELECT age_ratings.* FROM age_ratings /**innerjoin**/ /**where**/ GROUP BY age_ratings.id /**orderby**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            // Execute the SQL query and retrieve results.
            var output = cnn.Query<AgeRatingModel>(template.RawSql, template.Parameters);

            // Return the list of AgeRatingModel objects.
            return output.ToList();
        }


        // Method to mark a film as watched or unwatched.
        // Arguments:
        //   - filmId: The ID of the film to update.
        //   - watched: A boolean indicating whether the film is watched (true) or unwatched (false).
        void IDataAccess.setFilmWatched(int filmId, bool watched)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append WHERE clause to identify the film by its ID.
            builder = builder.Where("id = @whereId", new { whereId = filmId });

            // Generate SQL query template for updating the 'watched' status of the film.
            Template template = builder.AddTemplate("UPDATE films SET watched = @setWatched /**where**/", new { setWatched = watched });

            // Execute the SQL query to update the database.
            int rows = cnn.Execute(template.RawSql, template.Parameters);

            // Check if exactly one row was affected, otherwise throw an exception.
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }

        // Method to schedule a film to be watched on a specific date.
        // Arguments:
        //   - filmId: The ID of the film to schedule.
        //   - date: The date on which the film is scheduled to be watched.
        void IDataAccess.setFilmScheduled(int filmId, DateTime date)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Generate SQL query template for inserting a record into the 'soon_to_watch_films' table.
            Template template = builder.AddTemplate("INSERT INTO soon_to_watch_films (film_id, watch_date) VALUES (@setFilmId, @setDate)", new { setFilmId = filmId, setDate = date });

            // Execute the SQL query to insert the record into the database.
            int rows = cnn.Execute(template.RawSql, template.Parameters);

            // Check if exactly one row was affected, otherwise throw an exception.
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }

        // Method to set the rating of a film.
        // Arguments:
        //   - filmId: The ID of the film to update.
        //   - stars: The rating to set for the film.
        void IDataAccess.setFilmRating(int filmId, int stars)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Append WHERE clause to identify the film by its ID.
            builder = builder.Where("id = @whereId", new { whereId = filmId });

            // Generate SQL query template for updating the 'user_rating' of the film.
            Template template = builder.AddTemplate("UPDATE films SET user_rating = @setRating /**where**/", new { setRating = stars });

            // Execute the SQL query to update the database.
            int rows = cnn.Execute(template.RawSql, template.Parameters);

            // Check if exactly one row was affected, otherwise throw an exception.
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }

        // Method to set a comment for a film.
        // Arguments:
        //   - filmId: The ID of the film to which the comment belongs.
        //   - comment: The text of the comment.
        //   - commentDate: The date of the comment.
        void IDataAccess.setComment(int filmId, string comment, string commentDate)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Generate SQL query template for inserting or replacing a record into the 'comments' table.
            Template template = builder.AddTemplate("REPLACE INTO comments (id, film_id, comment_text, comment_date) VALUES ((SELECT id FROM comments WHERE film_id=@FilmId), @FilmId, @CommentText, @CommentDate)",
                new { CommentText = comment, CommentDate = commentDate, FilmId = filmId });

            // Execute the SQL query to insert or replace the record into the database.
            int rows = cnn.Execute(template.RawSql, template.Parameters);

            // Check if exactly one row was affected, otherwise throw an exception.
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }

        // Method to request a comment for a specific film.
        // Arguments:
        //   - filmId: The ID of the film for which to retrieve the comment.
        // Returns:
        //   - CommentModel: The comment associated with the specified film, if any; otherwise, null.
        CommentModel IDataAccess.requestComment(int filmId)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Generate SQL query template for selecting a comment for the specified film.
            Template template = builder.AddTemplate("SELECT * FROM comments WHERE film_id = @whereFilmId", new { whereFilmId = filmId });

            // Execute the SQL query to retrieve the comment from the database.
            var output = cnn.QueryFirstOrDefault<CommentModel>(template.RawSql, template.Parameters);

            // Return the retrieved comment model.
            return output;
        }

        CAgeRatingModel IDataAccess.requestAgeRating(int ratingId)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Generate SQL query template for selecting a comment for the specified film.
            Template template = builder.AddTemplate("SELECT * FROM user_rating WHERE ratingId = @whereRatingId", new { whereRatingId = ratingId });

            // Execute the SQL query to retrieve the comment from the database.
            var output = cnn.QueryFirstOrDefault<CAgeRatingModel>(template.RawSql, template.Parameters);

            // Return the retrieved comment model.
            return output;
        }

        // Method to remove a comment from the database.
        // Arguments:
        //   - commentId: The ID of the comment to remove.
        void IDataAccess.removeComment(int commentId)
        {
            // Initialize a SqlBuilder instance to dynamically construct SQL queries.
            SqlBuilder builder = new SqlBuilder();

            // Generate SQL query template for deleting a comment based on its ID.
            Template template = builder.AddTemplate("DELETE FROM comments WHERE id = @whereCommentId", new { whereCommentId = commentId });

            // Execute the SQL query to remove the comment from the database.
            int rows = cnn.Execute(template.RawSql, template.Parameters);

            // Check if exactly one row was affected, otherwise throw an exception.
            if (rows != 1) throw new Exception("Number of affected rows not 1, actually (" + rows.ToString() + ")");
        }

    }
}
