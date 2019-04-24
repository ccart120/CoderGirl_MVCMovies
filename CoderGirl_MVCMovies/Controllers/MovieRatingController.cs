using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {

        // Create an GET Action for Create which returns the above template as Content
        [HttpGet]
        public IActionResult Create()
        {
            return Content(htmlForm, "text/html");
        }

        private string htmlForm = @"
            <form method='post' action='/MovieRating/Create'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
                <button type='submit'>Rate</button>
            </form>";

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            return Content($"{movieName} has a rating of {rating}");
        }

        public IActionResult Index()
        {
            return View();
        }
        // Create a POST Action for Create which takes...
        // two string parameters which match the names of the input and select names in the template
        // The method should redirect to a the GET Action for Details. 
        // Be sure to pass the parameters as route values.

        //Create a GET Action for Details
        // Details should take the parameters passed by the POST Action for Create
        // Details should return a string as Content. This string should be in the format "{moveName} has a rating of {rating}"








    }
}