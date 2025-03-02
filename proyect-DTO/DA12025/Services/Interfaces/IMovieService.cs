using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetMovies();
        void AddMovie(MovieDTO movie);
        void DeleteMovie(string title);
        void UpdateMovie(MovieDTO movie);
        MovieDTO GetMovie(string title);
    }
}
