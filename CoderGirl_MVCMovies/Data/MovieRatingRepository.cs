using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Data
{
    static List<MovieRating> GetMovieRatings();
    static int nextId = 1;

    public class MovieRatingRepository : IMovieRatingRepository
    {
        int Save(MovieRating movieRating);



        public MovieRating GetById(int id);
        {
            return GetMovieRatings.SingleOrDefault(m => m.Id == id);
        }

        



        void Update(MovieRating movie);

        void Delete(int id);
    }
}
