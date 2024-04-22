using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary
{
    public interface IDataAccess // Funtions shall be synchronous and possibly throw exceptions
    {
        MetadataModel requestMetadata();
        List<FilmModel> requestFilms(int start, int amount, QueryModel query,bool isFirstLoad);
        int setFilmWatched(int id);
        int setFilmScheduled(int id, int date_unix_ts);
        string updateComment(int film_id, string comment, string commentDate);
        CommentModel requestComments(int film_id);

    }
}
