using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cinema_Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SearchController> _logger;

        public SearchController(AppDbContext context, ILogger<SearchController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult SearchView()
        {
            var movies = _context.Movies
                .Include(m => m.MovieGenres)
                .Include(m => m.MovieActors)
                .Include(m => m.Trailers)
                .ToList();
            var genres = _context.Genres.ToList();
            var actors = _context.Actors.ToList();
            var trailers = _context.Trailers.ToList();
            var viewModel = new CombinedMovieViewModel { Movies = movies, Genres = genres, Actors = actors, Trailers = trailers };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetMovieDetailsByTitle(string title)
        {
            try
            {
                var movie = _context.Movies
                    .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre)
                    .Include(m => m.MovieActors)
                    .ThenInclude(ma => ma.Actor)
                    .Include(m => m.Trailers)
                    .FirstOrDefault(m => m.Title == title);

                if (movie == null)
                {
                    _logger.LogWarning("Movie with title '{Title}' not found.", title);
                    return NotFound();
                }

                var trailerUrl = movie.Trailers?.FirstOrDefault()?.Url ?? "";

                var movieDetails = new
                {
                    title = movie.Title,
                    genres = string.Join(", ", movie.MovieGenres
                        .Where(mg => mg.Genre != null)
                        .Select(mg => mg.Genre.Title)), 
                    releaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
                    duration = $"{movie.Duration / 60}:{movie.Duration % 60:D2}",
                    stars = string.Join(", ", movie.MovieActors
                        .Where(ma => ma.Actor != null)
                        .Select(ma => $"{ma.Actor.FirstName} {ma.Actor.LastName}")),
                    description = movie.Description,
                    rating = movie.Rating,
                    posterUrl = Url.Content($"~/img_posters/{movie.Title}/{movie.Title}_SP.jpg"),
                    trailerUrl = trailerUrl
                };

                return Json(movieDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting movie details for title '{Title}'", title);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
