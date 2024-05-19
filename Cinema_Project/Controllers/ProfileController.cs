using Microsoft.AspNetCore.Mvc;
using Cinema_Project.ViewModels;
using Cinema_Project.Data;
using Microsoft.EntityFrameworkCore;
using Cinema_Project.Models;
using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace Cinema_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ProfileView()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                string userName = HttpContext.Session.GetString("UserName");

                var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    // Получаем список билетов, связанных с пользователем, по его ID
                    var tickets = _context.Tickets
                        .Where(t => t.UserId == user.Id)
                        .Include(t => t.Movie)
                        .Include(t => t.User) // Включаем данные о пользователе
                        .ToList();

                    var profileViewModel = new UserProfileViewModel(user, tickets, null); // Вторым аргументом передается null, так как список фильмов пока не передается

                    ViewBag.UserName = profileViewModel.UserName;
                    ViewBag.Email = profileViewModel.Email;
                    //ViewBag.Password = profileViewModel.Password;
                    //ViewBag.UserName = profileViewModel.UserName;

                    return View(profileViewModel);
                }
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
