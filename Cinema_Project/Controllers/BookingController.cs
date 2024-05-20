using Cinema_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Project.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult BookingView(int movieId)
        {
            var movie = _context.Movies
                .Where(m => m.MovieId == movieId)
                .Select(m => new
                {
                    m.Title,
                    m.Duration,
                    m.Rating,
                })
                .FirstOrDefault();

            if (movie == null)
            {
                return NotFound();
            }

            var screenings = _context.Screenings
                .Where(s => s.MovieId == movieId)
                .ToList();

            ViewBag.Movie = movie;
            ViewBag.Screenings = screenings;

            return View();
        }
    }
}
