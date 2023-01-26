using Lumia.Data;
using Lumia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lumia.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            List<Team> teams = _dataContext.Teams.Include(x=>x.Position).ToList();
            return View(teams);
        }

       
    }
}