using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.Data;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingCreateViewModel
    {
        public string MovieName { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }



        public static MovieRatingCreateViewModel GetMovieRatingCreateViewModel(int movieId)
        {
            //List<Director> directors = RepositoryFactory.GetDirectorRepository()
            //    .GetModels()
            //    .Cast<Director>()
            //    .ToList();

            MovieRatingCreateViewModel viewModel = new MovieRatingCreateViewModel();
            
            var movie = (Models.Movie)RepositoryFactory.GetMovieRepository().GetById(movieId)  ;
            string movieName = movie.Name;
            viewModel.MovieName = movieName;
            viewModel.MovieId = movieId;
            return viewModel;
        }
        public void Persist()
        {
            Models.MovieRating movieRating = new Models.MovieRating
            {
                MovieName = this.MovieName,
                MovieId = this.MovieId,
                Rating = this.Rating,
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }
    }
}
