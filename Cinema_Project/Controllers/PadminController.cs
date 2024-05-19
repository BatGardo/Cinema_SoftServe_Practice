using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class PadminController : Controller
    {
        public IActionResult AdminView()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }
    }
}
