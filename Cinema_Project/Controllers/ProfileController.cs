using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult ProfileView()
        {
            return View();
        }
    }
}
