using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class CommentModel
    {
        public FilmModel Film { get; set; } = null!;
        public string CommentText { get; set; }
        public string CommentDate { get; set; }


    }
}
