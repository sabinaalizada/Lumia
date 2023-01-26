using Lumia.Areas.Admin.viewModel;
using Lumia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser=await _userManager.FindByNameAsync(adminLoginViewModel.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError(" ", " Password or Username is incorrect");
                return View();

            }

            var result=await _signInManager.PasswordSignInAsync(appUser, adminLoginViewModel.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(" ", " Password or Username is incorrect");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
