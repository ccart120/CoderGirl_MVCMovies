using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieController : Controller
    {
        public static IMovieRespository movieRepository = RepositoryFactory.GetMovieRepository();
        public static IMovieRatingRepository movieRatingRepository = RepositoryFactory.GetMovieRatingRepository();
        public List<Movie> movies = movieRepository.GetMovies();
        public List<Director> directors = new List<Director>();
        public IActionResult Index()
        {

            //List<Movie> movieRatings = movieRepository.SetMovieRatings();
            //ViewBag.Directors = movies.Select(m => m.DirectorName).ToList();
            //GetAverageRating(movieRatings);
            return View(movies);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Directors = directors;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movieRepository.Save(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, Movie movie)
        {
            //since id is not part of the edit form, it isn't included in the model, thus it needs to be set from the route value
            //there are alternative patterns for doing this - for one, you could include the id in the form but make it hidden
            //feel free to experiment - the tests wont' care as long as you preserve the id correctly in some manner
            movie.Id = id;
            movieRepository.Update(movie);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }

        //takes the ratings associated with a particular movie and calculates the average
        //to find the ratings associated with a particular movie, look at each movie rating that has been created
        //check if its name equals its name and then call the rating
        //each of these rating, hold in a dictionary?
        //than for each movieName, calculate an average?

        /*
        public IActionResult GetAverageRating()
        {
            //double averageRating = 0;
            foreach (Movie movie in movies)
            {

                List<int> totalRatingsPerMovie = movie.Ratings;

                return totalRatingsPerMovie.Average();
                //totalRatingsPerMovie parse to int and then average
                //averageRating = totalRatingsPerMovie.Average
            }
            //return averageRating;


        }
        /*List<MovieRating> movieRatings = ratingRepository.GetMovieRatings();
       // MovieRating moveRating = ratingRepository.GetById(id).ToString();
        foreach (MovieRating movieRating in movieRatings)
        {
            if (m => m.Id == id)
            {
                mov
            }
        }
        return movieRatings.Average
        */

    }


    /*
    public IActionResult GetNumberOfRatings
    {

    }
    */
    }
