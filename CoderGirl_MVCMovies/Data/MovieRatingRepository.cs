using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        static List<MovieRating> movieRatings = new List<MovieRating>();

        static int nextId = 1;

        public void Delete(int id)
        {
            movieRatings.RemoveAll(m => m.Id == id);
        }

        public MovieRating GetById(int id)
        {
            return movieRatings.SingleOrDefault(m => m.Id == id);
        }

        public List<MovieRating> GetMovieRatings()
        {
            return movieRatings;
        }

        public int Save(MovieRating movieRating)
        {
            
            movieRating.Id = nextId;
            movieRatings.Add(movieRating);
            nextId++;
            return movieRating.Id;

        }

        public void Update(MovieRating movieName)
        {
            this.Delete(movieName.Id);
            movieRatings.Add(movieName);
        }
    }

}


      
    

        



        
  

