using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Cinema_Project.Models;
using Cinema_Project.ViewModels;
using System.Numerics;

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

        public IActionResult Auth()
        {
            var model = new CombinedAuthorizationViewModel
            {
                LoginVM = new LoginVM(),
                RegisterVM = new RegisterVM()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(CombinedAuthorizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.LoginVM.Username!, model.LoginVM.Password!, model.LoginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View("Auth", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(CombinedAuthorizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    FirstName = model.RegisterVM.FirstName,
                    LastName = model.RegisterVM.LastName,
                    Email = model.RegisterVM.Email,
                    UserName = model.RegisterVM.UserName,
                    PhoneNumber = model.RegisterVM.PhoneNumber
                };

                var result = await userManager.CreateAsync(user, model.RegisterVM.Password!);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Auth", model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
