using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    public class DBInMemory
    {
        private List<Movie> Movies { get; set; }

        public DBInMemory()
        {
            Movies = new List<Movie>();
            loadDefaultMovies();
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public void Add(Movie movie)
        {
            Movies.Add(movie);
        }

        public void Remove(Movie movie)
        {
            Movies.Remove(movie);
        }

        public Movie Get(string title)
        {
            Movie movie = Movies.FirstOrDefault(movie => movie.Title == title);
            if (movie == null)
            {
                throw new FileNotFoundException("Cannot find movie with this title");
            }
            return movie;
        }

        public int GetIndex(string title)
        {
            var movieIndex = Movies.IndexOf(Movies.Find(m => m.Title == title));

            if (movieIndex == -1)
            {
                throw new IndexOutOfRangeException("Cannot find selected index");
            }
            return movieIndex;
        }

        private void loadDefaultMovies()
        {
            Movies.Add(new Movie("Black Rain", "Ridley Scott", new DateTime(1989, 09, 22)));
            Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
            Movies.Add(new Movie("Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18)));
        }
    }
}
