using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    internal class MovieRepository : BaseRepository
    {
        static IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public override IModel GetById(int id)
        {
            Movie movie = (Movie)base.GetById(id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            return movie;
        }

        public override List<IModel> GetModels()
        {
            return models.Select(movie => SetMovieRatings(movie))
                .Select(movie => SetDirectorName(movie)).Cast<Movie>();
        }

        //why is this not recognizing the Movierating property MovieId?
        //tried to cast (MovieRating) but did not solve issue
        //Cast<MovieRating>() did not solve issue
        private Movie SetMovieRatings(Movie movie)
        {
            List<int> ratings = ratingRepository.GetModels()
                                                .Where(rating => (MovieRating)rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating).Cast<MovieRating>()
                                                .ToList();
            movie.Ratings = ratings;
            return movie;
        }

        private Movie SetDirectorName(Movie movie)
        {
            Director director = (Director)directorRepository.GetById(movie.DirectorId);
            movie.DirectorName = director.FullName;
            return movie;
        }
    }
}
