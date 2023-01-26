using Lumia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser
            {
                Fullname = "Sabina",
                UserName = "alizada",
            };

            await _userManager.CreateAsync(appUser,"Admin123");
            return Ok("yarandi");
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("Super Admin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);
            return Ok("Yarandi");

        }

        public async Task<IActionResult> AddRole()
        {


            AppUser appUser = await _userManager.FindByNameAsync("alizada");


            await _userManager.AddToRoleAsync(appUser, "Super Admin");
            return Ok("yarandi");
        }
    }
}
