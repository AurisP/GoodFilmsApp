﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class CCommentModel
    {
        public FilmModel Film { get; set; }
        public string CommentText { get; set; }
        public string CommentDate { get; set; }


    }
}
