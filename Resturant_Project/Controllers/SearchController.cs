using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Project.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }
    }
}
