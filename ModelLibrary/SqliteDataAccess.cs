using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary.Models;

namespace ModelLibrary
{
    public class SqliteDataAccess
    {
        public static List<FilmModel> LoadFilm()
        {

        }

        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.connectionString
        }
    }


}
