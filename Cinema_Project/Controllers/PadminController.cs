using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using System.Linq;

namespace Cinema_Project.Controllers
{
    public class PadminController : Controller
    {
        private readonly AppDbContext _context;

        public PadminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminView()
        {
            var screenings = _context.Screenings
                .Select(s => new ScreeningViewModel
                {
                    Id = s.ScreeningId, // Assuming the ScreeningId is the primary key
                    MovieTitle = s.Movie.Title,
                    HallName = "Зелена зала", // Assuming a fixed hall name for simplicity
                    ScreeningDate = s.ScreeningDate
                }).ToList();

            return View(screenings);
        }

        [HttpPost]
        public IActionResult DeleteScreening(int id)
        {
            var screening = _context.Screenings.Find(id);
            if (screening != null)
            {
                _context.Screenings.Remove(screening);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(AdminView));
        }
    }
}