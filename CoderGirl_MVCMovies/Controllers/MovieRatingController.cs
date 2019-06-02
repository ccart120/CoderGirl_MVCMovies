using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.ViewModels.MovieRating;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        private IRepository movieRespository = RepositoryFactory.GetMovieRepository();

       public IActionResult Index()
        {
            var movieRating = MovieRatingListViewModel.GetMovieRatingList();
            return View(movieRating);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            //I need to move this code to the viewmodel, I think
            //we need to get the movie objects by id and get their names out of there
            //then, we can assign the movienames and movieids to movierating objects
            //var movie = (Movie)movieRespository.GetById(movieId);
            //string movieName = movie.Name;
            

            //MovieRating movieRating = new MovieRating();
            //movieRating.MovieId = movieId;
            //movieRating.MovieName = movieName;
            MovieRatingCreateViewModel model = MovieRatingCreateViewModel.GetMovieRatingCreateViewModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(MovieRatingCreateViewModel model)
        {
            return RedirectToAction(controllerName: nameof(Movie), actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            MovieRatingEditViewModel model = MovieRatingEditViewModel.GetModel(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, MovieRatingEditViewModel model)
        {
            model.Persist(id);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            RepositoryFactory.GetMovieRatingRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}