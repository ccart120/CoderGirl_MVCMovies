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
        //public static Dictionary<Movie, double> movieAverages = new Dictionary<Movie, double>();

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
        //PopulateMovieList and foreach loop are from group
        /*private void PopulateMovieList()
        {
            //repository.SaveRating("The Matrix", 5);
            //repository.SaveRating("The Matrix", 3);
            //repository.SaveRating("The Matrix Reloaded", 2);
            //repository.SaveRating("The Matrix Reloaded", 3);
            //repository.SaveRating("The Matrix The really bad one", 2);
            //repository.SaveRating("The Matrix The really bad one", 1);

            foreach (int id in repository.GetIds())
            {
                Movie mov = new Movie();
                mov.Id = movieNames.Count + 1;
                mov.Name = repository.GetMovieNameById(id);
                mov.Rating = repository.GetRatingById(id);
                movieNames.Add(mov);
            }
        }*/

        /// TODO: Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: Be sure to include headers for Movie and Rating
        /// TODO: Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {

            
            //PopulateMovieList();
            Dictionary<string, double> movieAverages = new Dictionary<string, double>();
            List<string> uniqueMovieNames = movieNames.Distinct().ToList();
            foreach (string movieName in uniqueMovieNames)
            {

                //if (movieNames.Contains averagerating - call the getaveragerating method and delete it from below?
                //then add it to movieAverages
                movieAverages.Add(movieName, repository.GetAverageRatingByMovieName(movieName));
            }
            ViewBag.MovieRatings = movieAverages;

            return View();
            //return View("Index");
        }

        // TODO: Create a view MovieRating/Create and put the htmlForm there. Remember that html in a view should not be a string.
        // TODO: Change the input tag for movie name to be a drop down which has a list of movies from the movie repository
        // TODO: Change this method to return that view. 
        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.MovieNames = movieNames;
            return View();
            //return View("Create");
            // ViewBag.Movies = MovieController.movies;
            //return View();
        }

        // TODO: Save the movie/rating in the MovieRatingRepository before redirecting to the Details page
        // TODO: Redirect passing the values for the movieName and rating
        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            
            int id = repository.SaveRating(movieName, int.Parse(rating));

            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
            //return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        // TODO: The Details method should take an int parameter which is the id of the movie/rating to display.
        // TODO: Create a Details view which displays the formatted string with movie name and rating in an h2 tag. 
        // TODO: The Details view should include a link to the MovieRating/Index page
        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            
            ViewBag.movieName = movieName;
            ViewBag.movieRating = rating;
            return View();
            //return View("Details");
            //return Content($"{movieName} has a rating of {rating}");
        }
    }
}