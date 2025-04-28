using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Restaurant_Project.Data;

namespace Restaurant_Project.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string keyword)
        {
            var result = _context.Dishes
                .Where(x => x.Name.Contains(keyword.Trim())).ToList();
            return View(result);
        }
    }
}
