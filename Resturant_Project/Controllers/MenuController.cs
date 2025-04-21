using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Migrations;

namespace Restaurant_Project.Controllers
{
    public class MenuController : Controller
    {

        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Menu()
        {

            var menuModel = _context.Categories
                .Include(c => c.Dishes)
                .ToList();
            return View("Menu", menuModel);
        }


    }
}
