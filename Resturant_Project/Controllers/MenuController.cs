using Microsoft.AspNetCore.Mvc;

namespace Resturant_Project.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View("Menu");
        }
    }
}
