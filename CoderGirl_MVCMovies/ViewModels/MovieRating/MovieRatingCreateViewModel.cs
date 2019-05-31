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

        //I need to move this code to the viewmodel, I think
        //we need to get the movie objects by id and get their names out of there
        //then, we can assign the movienames and movieids to movierating objects
        //var movie = (Movie)movieRespository.GetById(movieId);
        //string movieName = movie.Name;


        public void Persist()
        {
            Models.MovieRating movieRating = new Models.MovieRating
            {
                MovieName = this.MovieName,
                MovieId = this.MovieId
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }
    }
}
