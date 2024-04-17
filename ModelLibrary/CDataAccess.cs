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
        public static List<FilmModel> requestFilms(int start, int amount)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Calculate the offset based on the start index and amount
                int offset = (start - 1) * amount;

                // Construct the SQL query with parameterized query and ORDER BY clause
                string query = "SELECT * FROM films ORDER BY title LIMIT @Amount OFFSET @Offset";

                // Execute the query with parameters using Dapper's Query method
                var output = cnn.Query<FilmModel>(query, new { Amount = amount, Offset = offset });
                return output.ToList();
            }
        }

        public List<GenreModel> requestGenres(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Construct the SQL query with parameterized query and WHERE clause based on the provided name
                string query = "SELECT * FROM genres";

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

        public List<DirectorModel> requestDirectors(string name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Construct the SQL query with parameterized query and WHERE clause based on the provided name
                string query = "SELECT * FROM directors";

                // If a non-empty name is provided
                if (!string.IsNullOrEmpty(name))
                {
                    query += " WHERE name LIKE @Name";
                    // Add wildcard characters to search for any part of the name
                    string searchTerm = $"%{name}%";
                    // Execute the query with parameters using Dapper's Query method
                    var output = cnn.Query<DirectorModel>(query, new { Name = searchTerm });
                    return output.ToList();
                }
                // If name is not provided or empty, retrieve all directors
                else
                {
                    var output = cnn.Query<DirectorModel>(query);
                    return output.ToList();
                }
            }
        }


        public List<ScheduledFilmModel> requestSchedules()
        {
            // Establish a connection to the SQLite database
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                // Construct the SQL query to retrieve scheduled films and their corresponding films
                string query = @"SELECT soon_to_watch_films.*, film.* FROM soon_to_watch_films
                                INNER JOIN films ON soon_to_watch_films.film_id = film.id";

                // Create a dictionary to store scheduled films temporarily
                var scheduledFilms = new Dictionary<int, ScheduledFilmModel>();

                // Execute the SQL query using Dapper's Query method, and map the results to ScheduledFilmModel and FilmModel objects
                cnn.Query<ScheduledFilmModel, FilmModel, ScheduledFilmModel>(
                    query,
                    (scheduledFilm, film) =>
                    {
                        // Mapping function: It receives a scheduled film and its corresponding film for each row returned by the query

                        // Check if the scheduled film is already in the dictionary
                        if (!scheduledFilms.TryGetValue(scheduledFilm.Id, out ScheduledFilmModel scheduledFilmEntry))
                        {
                            // If the scheduled film doesn't exist in the dictionary, create a new entry
                            scheduledFilmEntry = scheduledFilm;
                            scheduledFilmEntry.Film = film; // Associate the corresponding film with the scheduled film
                            scheduledFilms.Add(scheduledFilm.Id, scheduledFilmEntry);
                        }

                        return scheduledFilmEntry; // Return the scheduled film entry
                    },
                    splitOn: "id"); // Split the results based on the 'id' column

                // Convert the values of the dictionary (scheduled films) to a list and return it
                return scheduledFilms.Values.ToList();
            }
        }

        //###########
        public static List<AgeRatingModel> LoadAgeRatings()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AgeRatingModel>("select * from age_ratings", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StudioModel> LoadStudios()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudioModel>("select * from studios", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<DirectorModel> LoadDirectors()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DirectorModel>("select * from directors", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<GenreModel> LoadGenres()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GenreModel>("select * from genres", new DynamicParameters());
                return output.ToList();
            }
        }


        //##########


        public int removeComment(int id)
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
