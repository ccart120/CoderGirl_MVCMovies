﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class MovieRating
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Rating { get; set; }
    }
}