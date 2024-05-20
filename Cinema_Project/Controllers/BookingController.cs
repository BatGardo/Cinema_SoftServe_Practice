using Cinema_Project.Data;
using Cinema_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema_Project.ViewModels;

namespace Cinema_Project.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BookingController> _logger;

        public BookingController(AppDbContext context, ILogger<BookingController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult BookingView(int movieId)
        {
            var movie = _context.Movies
                .Where(m => m.MovieId == movieId)
                .Select(m => new
                {
                    m.MovieId,
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ticket.Showtime = DateTime.SpecifyKind(ticket.Showtime, DateTimeKind.Utc);

                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating ticket");
                    return Json(new { success = false, errors = new[] { ex.Message } });
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Invalid model state: {Errors}", errors);
                return Json(new { success = false, errors });
            }
        }
    }

}
