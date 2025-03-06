using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AquariumForum.Data;
using AquariumForum.Models;

namespace AquariumForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly AquariumForumContext _context;

        public HomeController(AquariumForumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussion.ToListAsync();
            return View(discussions);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
