using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using System.Diagnostics;
using Cinema_Project.Migrations;
using Cinema_Project.Data;

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


        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public IActionResult Privacy()
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
        public IActionResult Index(string search)
        {
            List<Movie> movies;

            if (!string.IsNullOrEmpty(search))
            {
                movies = _context.Movies.Where(m => m.Title.Contains(search)).ToList();
            }
            else
            {
                movies = _context.Movies.ToList();
            }

            return View(movies);
        }


    }
}
