using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoderGirl_MVCMovies.Models;
using CoderGirl_MVCMovies.Data;

namespace CoderGirl_MVCMovies.Controllers
{
    public class DirectorController : Controller
    {
        //private static List<Director> directors = directorRepository.GetDirectors();
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public IActionResult Index()
        {
            List<Director> directors = directorRepository.GetDirectors();
            return View(directors);
        }
        
        [HttpGet]
        public IActionResult Create()
        {

            //ViewBag.Directors = directors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director director)
        {
            directorRepository.Save(director);
            return RedirectToAction(actionName: nameof(Index));
        }

        


    }


}