using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Migrations;

namespace Restaurant_Project.Controllers
{
    public class MenuController : Controller
    {

        AppDbContext db = new AppDbContext();
        public IActionResult Menu()
        {

            var menuModel = db.Categories
                .Include(c => c.Dishes)
                .ToList();
            return View("Menu", menuModel);
        }


    }
}
