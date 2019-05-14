using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Models;

namespace CoderGirl_MVCMovies.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        private static List<Director> director = new List<Director>();
        private static int nextId = 1;
        static IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Director> GetDirectors()
        {
            throw new NotImplementedException();
        }

        public Director GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Director director)
        {
            throw new NotImplementedException();
        }

        public void Update(Director director)
        {
            throw new NotImplementedException();
        }
    }
}
