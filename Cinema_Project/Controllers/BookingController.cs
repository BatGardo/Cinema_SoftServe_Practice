using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult BookingView()
        {
            return View();
        }
    }
}
