using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();

        private string htmlForm = @"
            <form method='post'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>                    
                </select>
                <button type='submit'>Rate it</button>
            </form>";

       public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            //use the ViewBag to pass in the List<string> of movie names.??
            //used ViewBag in Create View
            return RedirectToAction(actionName: nameof(Index));
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(movieRatingRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit (int id,  MovieRating movieName)
        {
            movieRatingRepository.Update(movieName);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.Movie = movieName;
            ViewBag.Rating = rating;
            return View();
        }
    }
}