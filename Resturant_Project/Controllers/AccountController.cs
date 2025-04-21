using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult VerifyEmail()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
