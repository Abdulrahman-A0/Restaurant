using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Project.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
