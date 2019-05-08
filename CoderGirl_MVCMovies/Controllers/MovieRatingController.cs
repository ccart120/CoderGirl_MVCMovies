using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();
        
        public static List<string> movieNames = MovieController.movieNames.Values.ToList();
        public static Dictionary<string, int> movieRatings = new Dictionary<string, int>();

        private string htmlForm = @"
            <form method='post'>
                <button name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>                    
                </select>
                <button type='submit'>Rate it</button>
            </form>";
       

        /// TODO: DONE Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: DONE Be sure to include headers for Movie and Rating
        /// TODO: DONE Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {

            foreach (int id in repository.GetIds())
            {
                movieRatings.Add(repository.GetMovieNameById(id), repository.GetRatingById(id));
             
            }
            ViewBag.MovieRatings = movieRatings;

            return View();
            //return View("Index");
        }

        // TODO: DONE Create a view MovieRating/Create and put the htmlForm there. Remember that html in a view should not be a string.
        // TODO: DONE Change the input tag for movie name to be a drop down which has a list of movies from the movie repository
        // TODO: DONE Change this method to return that view. 
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.MovieNames = movieNames;
            return View();
            
        }

        // TODO: DONE Save the movie/rating in the MovieRatingRepository before redirecting to the Details page
        // TODO: DONE Redirect passing the values for the movieName and rating
        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            
            int id = repository.SaveRating(movieName, int.Parse(rating));

            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
           
        }

        // TODO: ID was not supposed to be passed in the Details method
        //The Details method should take an int parameter which is the id of the movie/rating to display.
        // TODO: DONE Create a Details view which displays the formatted string with movie name and rating in an h2 tag. 
        // TODO: DONE The Details view should include a link to the MovieRating/Index page
        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            
            ViewBag.movieName = movieName;
            ViewBag.movieRating = rating;
            return View();
           
        }
    }
}