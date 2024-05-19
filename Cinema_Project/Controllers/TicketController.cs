using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using Cinema_Project.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Cinema_Project.ViewModels;

namespace Cinema_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TicketController> _logger;

        public TicketController(AppDbContext context, ILogger<TicketController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketVM ticketModel)
        {
            try
            {
                _logger.LogInformation("Received request to create ticket.");

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Model state is valid.");

                    bool ticketExists = _context.Tickets.Any(t =>
                        t.Price == ticketModel.Price &&
                        t.Showtime == ticketModel.Showtime &&
                        t.HallNumber == ticketModel.HallNumber &&
                        t.RowNumber == ticketModel.RowNumber &&
                        t.SeatNumber == ticketModel.SeatNumber &&
                        t.MovieId == ticketModel.MovieId &&
                        t.UserId == ticketModel.UserId);

                    if (!ticketExists)
                    {
                        _logger.LogInformation("Ticket does not exist. Creating new ticket.");

                        var ticket = new Ticket
                        {
                            Price = ticketModel.Price,
                            Showtime = ticketModel.Showtime,
                            HallNumber = ticketModel.HallNumber,
                            RowNumber = ticketModel.RowNumber,
                            SeatNumber = ticketModel.SeatNumber,
                            MovieId = ticketModel.MovieId,
                            UserId = ticketModel.UserId
                        };

                        _context.Tickets.Add(ticket);
                        await _context.SaveChangesAsync();

                        _logger.LogInformation("Ticket created successfully.");
                        return Ok(new { message = "Ticket added to the database." });
                    }

                    _logger.LogWarning("Ticket with the same details already exists.");
                    return BadRequest(new { message = "Ticket with the same details already exists." });
                }

                _logger.LogWarning("Invalid data.");
                return BadRequest(new { message = "Invalid data." });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the ticket.");
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message });
            }
        }
    }
}
