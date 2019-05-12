using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        //create list of directors?
        private static List<Director> directors = new List<Director>();
        public IActionResult Index(List<Director> directors)
        {
            ViewBag.Directors = directors;
            return View();
        }
        
        [HttpGet]
        public IActionResult Create(List<Director> directors)
        {

            ViewBag.Directors = directors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            Save(director);
            return RedirectToAction(actionName: nameof(Index));
        }

        public int Save(Movie)
        {
            movieRating.Id = nextId++;
            movieRatings.Add(movieRating);
            return movieRating.Id;
        }


    }


}