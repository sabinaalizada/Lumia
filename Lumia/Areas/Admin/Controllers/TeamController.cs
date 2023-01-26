using Lumia.Data;
using Lumia.Helpers;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lumia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public TeamController(DataContext dataContext,IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        
        public IActionResult Index(int page=1)
        {
            var query = _dataContext.Teams.Include(x=>x.Position).AsQueryable();

            var paginated = PaginatedList<Team>.Create(query, 2, page);


            return View(paginated);
        }

        public IActionResult Create()
        {
            ViewBag.Posi = _dataContext.Positions.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Team team)
        {
            ViewBag.Posi = _dataContext.Positions.ToList();
            if (!ModelState.IsValid) return View(team);
            if (team.formFile == null)
            {
                ModelState.AddModelError("", "Form file is required");
                return View();
            }


            if(team.formFile != null)
            {
                if(team.formFile.ContentType!="image/jpeg" && team.formFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "incorrect type");
                    return View();
                }

                if(team.formFile.Length> 2097152)
                {
                    ModelState.AddModelError("", "incorrect type");
                    return View();
                }

                team.ImageUrl = team.formFile.SaveFile(_env.WebRootPath, "uploads/teams");
            }




            _dataContext.Teams.Add(team);
            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {

            ViewBag.Posi = _dataContext.Positions.ToList();

            Team team = _dataContext.Teams.FirstOrDefault(x => x.Id == id);

            if(team == null) return View();

            return View(team);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Team team)
        {
            if (!ModelState.IsValid) return View(team);

            Team existteam =_dataContext.Teams.FirstOrDefault(team=>team.Id == team.Id); 

            if(team == null) return View();


            if (team.formFile != null)
            {
                if (team.formFile.ContentType != "image/jpeg" && team.formFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "incorrect type");
                    return View();
                }

                if (team.formFile.Length > 2097152)
                {
                    ModelState.AddModelError("", "incorrect type");
                    return View();
                }

                string delete = Path.Combine(_env.WebRootPath, "uploads/teams", existteam.ImageUrl);


                if (System.IO.File.Exists(delete))
                {
                    System.IO.File.Delete(delete);
                }


                existteam.ImageUrl = team.formFile.SaveFile(_env.WebRootPath, "uploads/teams");
            }

            existteam.Name=team.Name;
            existteam.Insta = team.Insta;
            existteam.Face = team.Face;
            existteam.Twitter = team.Twitter;
            existteam.PositionId=team.PositionId;



            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Team deleteteam = _dataContext.Teams.Find(id);

            if(deleteteam == null) return View();

            string delete = Path.Combine(_env.WebRootPath, "uploads/teams", deleteteam.ImageUrl);

            if (System.IO.File.Exists(delete))
            {
                System.IO.File.Delete(delete);
            }


            _dataContext.Remove(deleteteam);
            _dataContext.SaveChanges();



            return RedirectToAction(nameof(Index));
        }
    }
}
