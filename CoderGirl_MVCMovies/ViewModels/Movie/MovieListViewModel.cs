using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movie
{
    public class MovieListViewModel
    {
        public static List<MovieListViewModel> GetMovieList()
        {
            return RepositoryFactory.GetMovieRepository()
                .GetModels()
                .Cast<Models.Movie>()
                .Select(movie => GetMovieListItemFromMovie(movie))
                .ToList();
        }

        private static MovieListViewModel GetMovieListItemFromMovie(Models.Movie movie)
        {
            return new MovieListViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                DirectorName = movie.DirectorName,
                Year = movie.Year,
                Ratings = movie.Ratings,
            };

     
        }

        public int Id { set; get; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        
    }
}
