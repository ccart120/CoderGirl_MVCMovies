﻿using System;
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
        private IMovieRepository movieRepository = RepositoryFactory.GetMovieRepository();

        public IActionResult Index()
        {
            
            return View(movieRatingRepository.GetMovieRatings());
        }

        [HttpGet]
        public IActionResult Create()
        {
            //List<string>names = movieRepository.GetMovies().Select(m => m.Name).ToList();

            //foreach (string name in names)
            //{
                //movieRating.MovieName = name;
            //}
            ViewBag.MovieNames = movieRepository.GetMovies().Select(m => m.Name).ToList(); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieRating movieRating)
        {
            movieRatingRepository.Save(movieRating);
            
            return RedirectToAction(actionName: nameof(Index));
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(movieRatingRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit (int id, MovieRating name)
        {
            movieRatingRepository.Update(name);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRatingRepository.Delete(id);

            return RedirectToAction(actionName: nameof(Index));
        }
    }
}