using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingListViewModel
    {
        public static List<MovieRatingListViewModel>GetMovieRatingList()
        {
            return RepositoryFactory.GetMovieRatingRepository()
                .GetModels()
                .Cast<Models.MovieRating>()
                .Select (movieRating => GetMovieRatingListItemFromMovieRating(movieRating))
                .ToList();
        }

        private static MovieRatingListViewModel GetMovieRatingListItemFromMovieRating(Models.MovieRating movieRating)
        {
            return new MovieRatingListViewModel
            {
                Id = movieRating.Id,
                MovieName = movieRating.MovieName,
                Rating = movieRating.Rating,
                
            };
        }
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
    }
}
