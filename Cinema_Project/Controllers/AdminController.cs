using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
