using Domain;
using Services.DataAccess;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void AddMovie(MovieDTO movie)
        {
            ValidateUniqueTitle(movie.Title);

            _dbInMemory.Movies.Add(ToEntity(movie));
        }

        public void DeleteMovie(string title)
        {
            MovieDTO movieToDelete = GetMovie(title);
            Movie? movie = _dbInMemory.Movies.Find(m => m.Title == movieToDelete.Title);
            _dbInMemory.Movies.Remove(movie);
        }

        public List<MovieDTO> GetMovies()
        {
            List<MovieDTO> moviesDTO = new List<MovieDTO>();

            foreach (var movie in _dbInMemory.Movies)
            {
                moviesDTO.Add(FromEntity(movie));
            }
            return moviesDTO;

        }

        public void UpdateMovie(MovieDTO movieToUpdate)
        {
            Movie? movie = _dbInMemory.Movies.Find(m => m.Title == movieToUpdate.Title);
            var movieToUpdateIndex = _dbInMemory.Movies.IndexOf(movie);

            _dbInMemory.Movies[movieToUpdateIndex] = ToEntity(movieToUpdate);
        }

        public MovieDTO GetMovie(string title)
        {
            Movie? movie = _dbInMemory.Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return FromEntity(movie);
        }

        private void ValidateUniqueTitle(String title)
        {
            foreach (var movie in _dbInMemory.Movies)
            {
                if (movie.Title == title)
                {
                    throw new ArgumentException("There`s a movie already defined with that title");
                }
            }
        }

        private Movie ToEntity(MovieDTO movieDTO)
        {
            return new Movie(movieDTO.Title, movieDTO.Director, movieDTO.ReleaseDate, movieDTO.Budget){};
        }

        private static MovieDTO FromEntity(Movie movie)
        {
            return new MovieDTO()
            {
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate,
            };
        }
    }
}
