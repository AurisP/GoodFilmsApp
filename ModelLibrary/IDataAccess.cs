using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public interface IDataAccess
    {
        int requestGenres();
        int requestDirectors();
        int requestSchedules();
        int requestFilms();
        int setFilmWatched(int id);
        int setFilmScheduled(int date);

    }
}
