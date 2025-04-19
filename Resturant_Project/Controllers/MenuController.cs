using Microsoft.AspNetCore.Mvc;
using Resturant_Project.Data;
using Resturant_Project.Migrations;

namespace Resturant_Project.Controllers
{
    public class MenuController : Controller
    {

        AppDbContext db =new AppDbContext();
        public IActionResult Menu()
        {

            var dishes =db.Dishes.ToList();
            return View("Menu", dishes);
        }


    }
}
