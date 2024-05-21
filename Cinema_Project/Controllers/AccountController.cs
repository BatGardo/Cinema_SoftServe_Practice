using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using Cinema_Project.ViewModels;
using System.Numerics;
using Microsoft.AspNetCore.Authentication;

namespace Cinema_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        HttpContext.Session.SetString("UserId", user.Id);
                        HttpContext.Session.SetString("UserName", user.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }



        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    Email = model.Email,
                    UserName = model.UserName,
                };

                var result = await userManager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("ProfileView", "Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
