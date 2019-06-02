using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movie
{
    public class MovieCreateViewModel
    {
        public static MovieCreateViewModel GetMovieCreateViewModel()
        {
            MovieCreateViewModel model = new MovieCreateViewModel();
            List<Director> directors = RepositoryFactory.GetDirectorRepository()
                .GetModels()
                .Cast<Director>()
                .ToList();
            model.Directors = directors;
            return model;
        }

        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }

        public void Persist()
        {
            Models.Movie movie = new Models.Movie()
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                DirectorName = this.DirectorName,
                Year = this.Year
            };
            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
