using Lumia.Data;
using Lumia.Helpers;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public PositionController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }

        public IActionResult Index(int page=1)
        {
            var query=_dataContext.Positions.AsQueryable();

            var paginated=PaginatedList<Position>.Create(query,2,page);
        


            return View(paginated);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Position  position)
        {
            if (!ModelState.IsValid) return View(position);

            

            _dataContext.Positions.Add(position);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            Position position = _dataContext.Positions.FirstOrDefault(x => x.Id == id);

            if (position == null) return View();

            return View(position);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Position  position)
        {
            if (!ModelState.IsValid) return View();

            Position existposition = _dataContext.Positions.FirstOrDefault(x => x.Id == position.Id);

            if (position == null) return View();




            existposition.Name = position.Name;
           



            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Position deletepos = _dataContext.Positions.Find(id);

            if (deletepos == null) return View();

            


            _dataContext.Positions.Remove(deletepos);
            _dataContext.SaveChanges();



            return RedirectToAction(nameof(Index));
        }
    }
}
