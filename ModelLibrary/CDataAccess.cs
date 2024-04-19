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

namespace ModelLibrary
{

    public class CDataAccess : IDataAccess
    {
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; // TODO: What is this, this is cursed.
        }

        private IDbConnection cnn;

        public CDataAccess()
        {
            this.cnn = new SQLiteConnection(LoadConnectionString());
            this.cnn.Open();
        }

        MetadataModel IDataAccess.requestMetadata()
        {
            return new MetadataModel( // TODO: @Auris any way to do this in 1 request?
                cnn.Query<DirectorModel>((new SqlBuilder()).AddTemplate("SELECT * FROM directors").RawSql).ToList(),
                cnn.Query<GenreModel>((new SqlBuilder()).AddTemplate("SELECT * FROM genres").RawSql).ToList(),
                cnn.Query<StudioModel>((new SqlBuilder()).AddTemplate("SELECT * FROM studios").RawSql).ToList(),
                cnn.Query<LanguageModel>((new SqlBuilder()).AddTemplate("SELECT * FROM languages").RawSql).ToList(),
                cnn.Query<AgeRatingModel>((new SqlBuilder()).AddTemplate("SELECT * FROM age_ratings").RawSql).ToList()
            );
        }

        List<FilmModel> IDataAccess.requestFilms(int start, int amount, QueryModel query)
        {
            int offset = (start - 1) * amount;
            SqlBuilder builder = new SqlBuilder();
            if (query.Query != null)
            {
                builder = builder.Where("title LIKE @Query", new { Query = "%" + query.Query + "%" });
            }
            Template template;
            if (query.Random)
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ ORDER BY RANDOM() LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            else
            {
                template = builder.AddTemplate("SELECT * FROM films /**where**/ LIMIT @Amount OFFSET @Offset", new { Amount = amount, Offset = offset });
            }
            var output = cnn.Query<FilmModel>(template.RawSql, template.Parameters);
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
    }




}
