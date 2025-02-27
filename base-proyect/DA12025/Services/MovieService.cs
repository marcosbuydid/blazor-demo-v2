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
            Movie movieToDelete = GetMovie(title);
            _dbInMemory.Movies.Remove(movieToDelete);
        }

        public List<Movie> GetMovies()
        {
            return _dbInMemory.Movies;
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(string title)
        {
            Movie? movie = _dbInMemory.Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return movie;
        }
    }
}
