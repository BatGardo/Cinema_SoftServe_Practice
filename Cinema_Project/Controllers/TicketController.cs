using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using Cinema_Project.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Cinema_Project.ViewModels;

namespace Cinema_Project.Controllers
{
    public class TicketController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TicketController> _logger;

        public TicketController(AppDbContext context, ILogger<TicketController> logger)
        {
            _context = context;
            _logger = logger;
        }
    }
}
