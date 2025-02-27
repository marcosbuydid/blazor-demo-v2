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
        public List<Movie> Movies { get; set; }

        public DBInMemory()
        {
            Movies = new List<Movie>();
            loadDefaultMovies();
        }

        private void loadDefaultMovies()
        {
            Movies.Add(new Movie("Black Rain", "Ridley Scott", new DateTime(1989, 09, 22)));
            Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
            Movies.Add(new Movie("Training Day", "Antoine Fuqua", new DateTime(2002, 01, 18)));
        }
    }
}
