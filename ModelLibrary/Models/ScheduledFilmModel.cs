﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class ScheduledFilmModel
    {
        public int Id { get; set; }

        public FilmModel Film { get; set; }

        public string WatchDate {  get; set; }

    }
}
