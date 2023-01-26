using Lumia.Data;
using Lumia.Helpers;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;

        public SettingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index(int page=1)
        {
            var query = _dataContext.Settings.AsQueryable();

            var paginated = PaginatedList<Setting>.Create(query, 2, page);


            return View(paginated);
        }

        public IActionResult Update(int id)
        {

            Setting setting = _dataContext.Settings.FirstOrDefault(x => x.Id == id);

            if (setting == null) return View();

            return View(setting);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {
            if(!ModelState.IsValid) return View();
            Setting existsett = _dataContext.Settings.FirstOrDefault(x => x.Id == setting.Id);

            if (setting == null) return View();




            existsett.Value = setting.Value;


            
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
