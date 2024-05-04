using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public FilmModel Film { get; set; }
        public string Comment_Text { get; set; }
        public string Comment_Date { get; set; }

    }
}
