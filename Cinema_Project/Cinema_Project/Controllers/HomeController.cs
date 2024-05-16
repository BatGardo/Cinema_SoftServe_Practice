using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using System.Diagnostics;
using Cinema_Project.Migrations;
using Cinema_Project.Data;
using Cinema_Project.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {






        public IActionResult index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Auth()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






    }
}
