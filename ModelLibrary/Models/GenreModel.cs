﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class GenreModel
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        //##
        public bool Chosen { get; set; }
        //###
    }
}
