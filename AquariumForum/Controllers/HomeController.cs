using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace AquariumForum.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
