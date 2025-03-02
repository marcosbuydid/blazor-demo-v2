﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class MovieDTO
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        public int Budget { get; set; }

        public Movie ToEntity()
        {
            return new Movie(Title, Director, ReleaseDate, Budget)
            {
                Title = Title,
                Director = Director,
                ReleaseDate = ReleaseDate,
                Budget = Budget
            };
        }

        public static MovieDTO FromEntity(Movie movie)
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
