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

namespace ModelLibrary
{

    public class CDataAccess
    {
        public static List<FilmModel> loadFilm(int start, int amount)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Calculate the offset based on the start index and amount
                int offset = (start - 1) * amount;

                // Construct the SQL query with parameterized query and ORDER BY clause
                string query = "SELECT * FROM film ORDER BY title LIMIT @Amount OFFSET @Offset";

                // Execute the query with parameters using Dapper's Query method
                var output = cnn.Query<FilmModel>(query, new { Amount = amount, Offset = offset });
                return output.ToList();
            }
        }

        public List<GenreModel> RequestGenres(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Construct the SQL query with parameterized query and WHERE clause based on the provided name
                string query = "SELECT * FROM genre";

                // If a non-empty name is provided, add a WHERE clause to filter by genre name
                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE genre = @Name";
                }

                // Execute the query with parameters using Dapper's Query method
                var output = cnn.Query<GenreModel>(query, new { Name = name });
                return output.ToList();
            }
        }

        public List<DirectorModel> RequestDirectors(string forename, string surname)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Construct the SQL query with parameterized query and WHERE clause based on the provided forename and surname
                string query = "SELECT * FROM director WHERE";

                // If both forename and surname are provided
                if (!string.IsNullOrEmpty(forename) && !string.IsNullOrEmpty(surname))
                {
                    query += " forename = @Forename AND surname = @Surname";
                    // Execute the query with parameters using Dapper's Query method
                    var output = cnn.Query<DirectorModel>(query, new { Forename = forename, Surname = surname });
                    return output.ToList();
                }
                // If only forename is provided
                else if (!string.IsNullOrEmpty(forename))
                {
                    query += " forename = @Forename";
                    // Execute the query with parameters using Dapper's Query method
                    var output = cnn.Query<DirectorModel>(query, new { Forename = forename });
                    return output.ToList();
                }
                // If only surname is provided
                else if (!string.IsNullOrEmpty(surname))
                {
                    query += " surname = @Surname";
                    // Execute the query with parameters using Dapper's Query method
                    var output = cnn.Query<DirectorModel>(query, new { Surname = surname });
                    return output.ToList();
                }
                // If neither forename nor surname is provided
                else
                {
                    // Retrieve all directors if no search criteria provided
                    query = "SELECT * FROM directors";
                    var output = cnn.Query<DirectorModel>(query);
                    return output.ToList();
                }
            }
        }


        public int requestSchedules()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = @"SELECT sf.*, f.* 
                             FROM scheduled_films sf
                             INNER JOIN films f ON sf.film_id = f.id";

                var scheduledFilms = new Dictionary<int, ScheduledFilmModel>();

                cnn.Query<ScheduledFilmModel, FilmModel, ScheduledFilmModel>(query, (scheduledFilm, film) =>
                    {
                        ScheduledFilmModel scheduledFilmEntry;

                        // Check if the scheduled film is already in the dictionary
                        if (!scheduledFilms.TryGetValue(scheduledFilm.Id, out scheduledFilmEntry))
                        {
                            // If not, create a new entry in the dictionary
                            scheduledFilmEntry = scheduledFilm;
                            scheduledFilmEntry.Film = film;
                            scheduledFilms.Add(scheduledFilm.Id, scheduledFilmEntry);
                        }

                        return scheduledFilmEntry;
                    },
                    splitOn: "id");

                return scheduledFilms.Values.ToList();
            }
        }

        public int requestFilms()
        {
            throw new NotImplementedException();
        }

        public int setFilmWatched(int id)
        {
            throw new NotImplementedException();
        }

        public int setFilmScheduled(int date)
        {
            throw new NotImplementedException();
        }

        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }


}
