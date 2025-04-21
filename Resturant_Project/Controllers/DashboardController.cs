using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;

namespace Restaurant_Project.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Category()
        {
            var categoryModel = _context.Categories.ToList();
            return View(categoryModel);
        }
        public IActionResult Dishes()
        {
            var dishesModel = _context.Dishes.ToList();
            return View(dishesModel);
        }
    }
}
