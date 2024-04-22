﻿using System;
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

        List<FilmModel> IDataAccess.requestFilms(int start, int amount, QueryModel queryModel, bool isFirstLoad)
        {
            int offset = (start - 1) * amount;
            SqlBuilder builder = new SqlBuilder();
            if (queryModel.Query != null)
            {
                builder = builder.Where("title LIKE @Query", new { Query = "%" + queryModel.Query + "%" });
            }
            Template template;
            if (queryModel.Random)
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ ORDER BY RANDOM() LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            else if (queryModel.Query != null)
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });

            }
            else
            {
                template = builder.AddTemplate("SELECT * FROM films ORDER BY title");
            }

            var output = cnn.Query<FilmModel>(template.RawSql, template.Parameters);
            //string query = "SELECT * FROM films ORDER BY title";

            //var output = cnn.Query<FilmModel>(query);


            if (queryModel.ReleaseYear != 0)
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
            }

            if (isFirstLoad)
            {
                isFirstLoad = false;
                queryModel.Random = false;
            }

            return output.ToList();
        }

        int IDataAccess.setFilmWatched(int id)
        {
            throw new NotImplementedException();
        }

        int IDataAccess.setFilmScheduled(int id, int date_unix_ts)
        {
            throw new NotImplementedException();
        }

        public static List<AgeRatingModel> LoadAgeRatings()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AgeRatingModel>("select * from age_ratings", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<LanguageModel> LoadLanguages()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LanguageModel>("select * from languages", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<LanguageFilmModel> LoadLanguagesFilms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<LanguageFilmModel>("select * from languages_films", new DynamicParameters());
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

        public static List<GenreFilmModel> LoadGenresFilms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<GenreFilmModel>("select * from genres_films", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<StudioFilmModel> LoadStudioFilms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<StudioFilmModel>("select * from studios_films", new DynamicParameters());
                return output.ToList();
            }
        }



        public static List<DirectorFilmModel> LoadDirectorFilms()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DirectorFilmModel>("select * from directors_films", new DynamicParameters());
                return output.ToList();
            }
        }



    }




}
