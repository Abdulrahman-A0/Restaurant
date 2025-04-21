using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Project.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Dishes()
        {
            return View();
        }
    }
}
