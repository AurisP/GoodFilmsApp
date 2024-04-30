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
        List<FilmModel> requestFilms(int offset, int amount, QueryModel query);
        void setFilmWatched(int id, bool watched);
        void setFilmScheduled(int id, long date_unix_ts);
        void setFilmRating(int id, int stars);
        void setComment(int film_id, string comment, string commentDate);
        CommentModel requestComment(int film_id);
        void removeComment(int comment_id);

    }
}
