﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRepository : IMovieRespository
    {
        static List<Movie> movies = new List<Movie>();
        static int nextId = 1;
        static IMovieRatingRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();

        public void Delete(int id)
        {
            movies.RemoveAll(m => m.Id == id);
        }

        public Movie GetById(int id)
        {
            //TODO: Insert MovieRatings
            Movie movie = movies.SingleOrDefault(m => m.Id == id);
            List<int> ratings = ratingRepository.GetMovieRatings().Where(rating => rating.MovieId == id)
                .Select(rating => rating.Rating).ToList();
            movie = SetMovieRatings(movie);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            //TODO: foreach movie insert MRs
           return movies.Select(movie => SetMovieRatings(movie)).ToList();
            
        }

       

        public int Save(Movie movie)
        {
            movie.Id = nextId++;
            movies.Add(movie);
            return movie.Id;
        }

        public void Update(Movie movie)
        {
            //there are many ways to accomplish this, this is just one possible way
            //the upside is that it is relatively simple, 
            //the (possible) downside is that it doesn't preserve the order in the list
            //as the AC doesn't specify, I am going with the simpler solution
            //once we start using the database this pattern will be simplified
            this.Delete(movie.Id);
            movies.Add(movie);
        }
        private Movie SetMovieRatings(Movie movie)
        {
            List<int> ratings = ratingRepository.GetMovieRatings()
              .Where(rating => rating.MovieId == movie.Id)
              .Select(rating => rating.Rating).ToList();
            movie.Ratings = ratings;
            return movie;
        }
    }
}
