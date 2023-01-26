using Lumia.Areas.Admin.viewModel;
using Lumia.Data;
using Lumia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(DataContext dataContext,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<AppUser> signInManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AdminRegisterViewModel adminRegisterViewModel)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser=null;

            appUser = _dataContext.Users.FirstOrDefault(x=>x.NormalizedUserName==adminRegisterViewModel.Username.ToUpper());

            if (appUser != null)
            {
                ModelState.AddModelError(" ", " Already exist");
                return View();
            }

            appUser = _dataContext.Users.FirstOrDefault(x => x.NormalizedEmail == adminRegisterViewModel.EmaIL.ToUpper());

            if (appUser != null)
            {
                ModelState.AddModelError(" ", " Already exist");
                return View();
            }

            var result =await _userManager.CreateAsync(appUser,adminRegisterViewModel.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(" ", item.Description);

                }
                return View();
            }

            var result1 = await _userManager.AddToRoleAsync(appUser, "Admin");
            if (!result1.Succeeded)
            {
                ModelState.AddModelError(" ", " Role is incorrect");
                return View();
            }

            await _signInManager.SignInAsync(appUser, isPersistent: false);

            return RedirectToAction("login", "account");
        }

    }
}
