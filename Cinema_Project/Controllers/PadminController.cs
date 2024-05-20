using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using System.Linq;
using Cinema_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cinema_Project.Controllers
{
    public class PadminController : Controller
    {
        private readonly AppDbContext _context;

        public PadminController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdminView()
        {
            // Отримання списку всіх фільмів і сеансів з бази даних
            var screenings = await _context.Screenings
                .Include(s => s.Movie)
                .ToListAsync();

            var movies = await _context.Movies.ToListAsync();

            // Створення об'єкту CombinedScreeningMovieViewModel
            var viewModel = new CombinedScreeningMovieViewModel
            {
                Screenings = screenings,
                Movies = movies
            };

            // Передача моделі у представлення
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteScreening(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);
            if (screening != null)
            {
                _context.Screenings.Remove(screening);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AdminView));
        }

        public IActionResult AddMovie()
        {
            return View();
        }














		public IActionResult AddWatchtime()
		{
			var movies = _context.Movies
				.Include(m => m.MovieGenres)
				.Include(m => m.MovieActors)
				.Include(m => m.Trailers)
				.ToList();
			var genres = _context.Genres.ToList();

			var model = new ScreeningMovieViewModel
			{
				Screening = new ScreeningViewModel(),
				Movie = new CombinedMovieViewModel
				{
					Movies = movies,
					Genres = genres
				}
			};

			return View(model);
		}



		[HttpGet]
		public IActionResult SearchMovies(string query)
		{
			var movies = _context.Movies
				.Where(m => m.Title.Contains(query))
				.ToList();

			return Json(movies);
		}


		[HttpPost]
		public async Task<IActionResult> CreateScreening([FromBody] ScreenVM model)
		{
			try
			{

				// Проверка переменных на корректность
				if (model.Id <= 0)
				{
					return BadRequest(new { message = "Invalid movieId" });
				}

				if (model.HallName <= 0)
				{
					return BadRequest(new { message = "Invalid hallNumber" });
				}

				if (string.IsNullOrWhiteSpace(model.Date))
				{
					return BadRequest(new { message = "Date is required" });
				}

				if (!DateTime.TryParse(model.Date, out DateTime parsedDate))
				{
					return BadRequest(new { message = "Invalid date format" });
				}

				if (model.Time < 0 || model.Time > 23)
				{
					return BadRequest(new { message = "Invalid time" });
				}

				if (model.Price < 0)
				{
					return BadRequest(new { message = "Invalid price" });
				}

				// Преобразуем строку с датой и время в DateTime
				DateTime screeningDate = parsedDate.Date + TimeSpan.FromHours(model.Time);

				// Создаем новый объект Screening
				//var screening = new Screening
				//{
				//	MovieId = movieId,
				//	HallNumber = hallNumber,
				//	ScreeningDate = screeningDate,
				//	Price = price
				//};

				// Добавляем новый объект в контекст данных
				//_context.Screenings.Add(screening);

				// Сохраняем изменения в базе данных
				await _context.SaveChangesAsync();

				// Возвращаем результат успешного выполнения
				return Ok(new { message = "Screening created successfully" });
			}
			catch (Exception ex)
			{
				// Если произошла ошибка, возвращаем статус 500 с сообщением об ошибке
				return StatusCode(500, new { message = "Error creating screening", error = ex.Message });
			}
		}





	}
}