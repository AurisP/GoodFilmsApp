﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class DirectorFilmModel
    {
        public int Id { get; set; }
        public DirectorModel Director { get; set; }
        public FilmModel Film { get; set; }
    }
}
