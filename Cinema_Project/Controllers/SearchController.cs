﻿using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult SearchView()
        {
            var movies = _context.Movies
                .Include(m => m.MovieGenres)
            .Include(m => m.MovieActors)
                .ToList();
            var genres = _context.Genres.ToList();
            var actors = _context.Actors.ToList();
            var viewModel = new CombinedMovieViewModel { Movies = movies, Genres = genres, Actors = actors };
            return View(viewModel);
        }
    }
}