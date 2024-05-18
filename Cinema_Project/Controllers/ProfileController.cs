using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult ProfileView()
        {
            return View();
        }
    }
}