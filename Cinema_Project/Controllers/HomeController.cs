using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using System.Diagnostics;
using Cinema_Project.Migrations;
using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ProfileViewLayout();

            var movies = _context.Movies
                .Include(m => m.MovieGenres)
                .Include(m => m.MovieActors)
                .Include(m => m.Trailers)
                .Include(m => m.Screenings)
                .Where(m => m.Screenings.Any())
                .OrderBy(m => m.Screenings.Min(s => s.ScreeningDate))
                .ToList();

            var genres = _context.Genres.ToList();
            var actors = _context.Actors.ToList();
            var trailers = _context.Trailers.ToList();

            var viewModel = new CombinedMovieViewModel
            {
                Movies = movies,
                Genres = genres,
                Actors = actors,
                Trailers = trailers
            };

            return View(viewModel);
        }



        public string ProfileViewLayout()
        {
            string userName = HttpContext.Session.GetString("UserName"); 
            if (string.IsNullOrEmpty(userName))
            {
                userName = "Guest";
            }
            ViewBag.UserName = userName;
            return userName;
        }




        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult booking()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                .Include(m => m.MovieActors)
                .ToList();

            return Json(movies);
        }
    }
}
