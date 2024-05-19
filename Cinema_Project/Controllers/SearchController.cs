using Microsoft.AspNetCore.Mvc;

namespace Cinema_Project.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult SearchView()
        {
            return View();
        }
    }
}
