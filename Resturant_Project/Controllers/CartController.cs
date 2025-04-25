using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Project.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}
