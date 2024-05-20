using Cinema_Project.Data;
using Cinema_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema_Project.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Cinema_Project.Controllers
{
    [Authorize]
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

            var tickets = _context.Tickets
                .Where(t => t.MovieId == movieId)
                .ToList();

            ViewBag.Movie = movie;
            ViewBag.Screenings = screenings;
            ViewBag.Tickets = tickets;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetReservedSeats(int movieId, DateTime showtime, int hallNumber)
        {
            var utcShowtime = DateTime.SpecifyKind(showtime, DateTimeKind.Utc);
            var reservedSeats = await _context.Tickets
                .Where(t => t.MovieId == movieId && t.Showtime == utcShowtime && t.HallNumber == hallNumber)
                .Select(t => new { t.RowNumber, t.SeatNumber })
                .ToListAsync();

            return Json(reservedSeats);
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
                    return Json(new { success = true, redirectUrl = Url.Action("ProfileView", "Profile") });
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
