using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static Dictionary<int, string> movieNames = new Dictionary<int, string>();
        private static int nextIdToUse = 1;

        public IActionResult Index()
        {
            ViewBag.MovieNames = movieNames;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string movie)
        {
            movieNames.Add(nextIdToUse, movie);
            nextIdToUse++;
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}