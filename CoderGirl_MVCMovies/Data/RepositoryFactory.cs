﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public static class RepositoryFactory
    {
        private static IMovieRatingRepository movieRatingRepository;

        public static IMovieRatingRepository GetMovieRatingRepository()
        {
            
            if (movieRatingRepository == null)
                movieRatingRepository = new MovieRatingRepository();
            // TODO: DONE new up your implementation class here
            return movieRatingRepository;
        }

        //public Factory()
        //{
           
            //this.GetMovieRatingRepository = new Movie();
            
        //}
    }
}
