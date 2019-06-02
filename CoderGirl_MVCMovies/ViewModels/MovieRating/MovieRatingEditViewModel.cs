using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRating
{
    public class MovieRatingEditViewModel
    {

        public static MovieRatingEditViewModel GetModel(int id)
        {
            Models.MovieRating movieRating = (Models.MovieRating)RepositoryFactory.GetMovieRatingRepository().GetById(id);
            return new MovieRatingEditViewModel
            {
                Rating = movieRating.Rating,
                MovieName = movieRating.MovieName,
                MovieId = movieRating.MovieId,


            };
        }

        public int Rating { get; set; }
        public string MovieName { get; set; }
        public int MovieId { get; set; }

        public void Persist(int id)
        {
            Models.MovieRating movieRating = new Models.MovieRating
            {
                Id = id,
                MovieName = this.MovieName,
                Rating = this.Rating,
                MovieId = this.MovieId
            };
            RepositoryFactory.GetMovieRatingRepository().Update(movieRating);
        }
    }
}
