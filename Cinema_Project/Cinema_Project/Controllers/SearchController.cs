﻿using Cinema_Project.Data;
using Cinema_Project.Models;
using Cinema_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Project.Controllers
{
    public class SearchController : Controller
    {

        private readonly ILogger<SearchController> _logger;
        private readonly AppDbContext _context;

        public SearchController(ILogger<SearchController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult MainLogic()
        {
            var genres = _context.Genres.ToList();
            var movies = _context.Movies.Include(m => m.MovieGenres).ToList(); // Включаем связанные жанры
            var viewModel = new MovieGenreViewModel { Movies = movies, Genres = genres };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetMovieDetails(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            return PartialView("_MovieDetailsPartial", movie);
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            List<Movie> movies;

            if (!string.IsNullOrEmpty(search))
            {
                movies = _context.Movies.Where(m => m.Title.Contains(search)).ToList();
            }
            else
            {
                movies = new List<Movie>();
            }

            return Json(movies);
        }

        [HttpGet]
        public IActionResult FilterMovies(List<int> genres)
        {
            var movies = _context.Movies
                .Where(m => m.MovieGenres.Any(g => genres.Contains(g.GenreId)))
                .Include(m => m.MovieGenres)
                .ToList();

            return Json(movies);
        }
    }
}
