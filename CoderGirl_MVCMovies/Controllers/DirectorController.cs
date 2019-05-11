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
        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpGet]
        public IActionResult Create(Director director)
        {
            
            director.FirstName = string firstName;
            return View();
        }*/
    }


}