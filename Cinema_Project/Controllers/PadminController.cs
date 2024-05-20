using Cinema_Project.Data;
using Cinema_Project.Models;
using Cinema_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            var screenings = await _context.Screenings
                .Include(s => s.Movie)
                .ToListAsync();

            var movies = await _context.Movies.ToListAsync();

            var viewModel = new CombinedScreeningMovieViewModel
            {
                Screenings = screenings,
                Movies = movies
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(AdminView));
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

        public async Task<IActionResult> AddMovie()
        {
            var genres = await _context.Genres.ToListAsync();
            var actors = await _context.Actors.ToListAsync();

            var model = new MovieAddVM
            {
                Genres = genres,
                Actors = actors
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieAddVM model)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ReleaseDate = model.ReleaseDate,
                    Duration = model.Duration,
                    Rating = model.Rating
                };

                if (model.SelectedGenreIds != null)
                {
                    foreach (var genreId in model.SelectedGenreIds)
                    {
                        movie.MovieGenres.Add(new MovieGenre { GenreId = genreId });
                    }
                }

                if (model.SelectedActorIds != null)
                {
                    foreach (var actorId in model.SelectedActorIds)
                    {
                        movie.MovieActors.Add(new MovieActor { ActorId = actorId });
                    }
                }

                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminView));
            }

            model.Genres = await _context.Genres.ToListAsync();
            model.Actors = await _context.Actors.ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteSQL([FromBody] SqlQueryModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.SqlQuery))
            {
                return BadRequest("Invalid SQL query");
            }

            try
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = model.SqlQuery;
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return Ok("SQL query executed successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error executing SQL query: {ex.Message}");
            }
        }

        public IActionResult AddWatchtime()
        {
            return View();
        }
    }

    public class SqlQueryModel
    {
        public string SqlQuery { get; set; }
    }
}
