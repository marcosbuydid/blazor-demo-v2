﻿using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetMovies();
        void AddMovie(Movie movie);
        void DeleteMovie(string title);
        void UpdateMovie(Movie movie);
        Movie GetMovie(string title);
    }
}
