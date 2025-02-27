using Services.DataAccess;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly DBInMemory _dbInMemory;

        public MovieService(DBInMemory dbInMemory)
        {
            _dbInMemory = dbInMemory;
        }

        public void AddMovie(Movie movie)
        {
            _dbInMemory.Movies.Add(movie);
        }

        public void DeleteMovie(string title)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            return _dbInMemory.Movies;
        }

        public Movie SearchMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
