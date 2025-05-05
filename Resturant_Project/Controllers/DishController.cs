using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DishController : Controller
    {
        private readonly AppDbContext db;

        public DishController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var dishesModel = db.Dishes.ToList();
            return View(dishesModel);
        }

        public IActionResult NotFountPage()
        {
            return View();
        }
        public IActionResult Create()
        {
            var categores = db.Categories.ToList();

            return View(categores);
        }
        [HttpPost]
        public IActionResult Create(Dish product, IFormFile Image)
        {

            if (Image.Length > 0)
            {
                // var filePath = Path.GetTempFileName();

                var fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", fileName);


                using (var stream = System.IO.File.Create(filePath))
                {
                    Image.CopyTo(stream);
                }

                product.Image = fileName;
            }
            // Category category=new Category() { Name= CategoryName };
            db.Dishes.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int Id)
        {
            var product = db.Dishes.Find(Id);
            var categores = db.Categories.ToList();
            if (product != null)
            {
                ViewData["categores"] = categores;
                return View(product);
            }
            else
            {

                return RedirectToAction("NotFountPage");
            }
        }
        [HttpPost]
        public IActionResult Edit(Dish product, IFormFile photo)
        {
            var oldproduct = db.Dishes.AsNoTracking().FirstOrDefault(e => e.Id == product.Id);


            if (photo != null && photo.Length > 0)
            {
                // var filePath = Path.GetTempFileName();

                var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", fileName);
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", oldproduct.Image);


                using (var stream = System.IO.File.Create(filePath))
                {
                    photo.CopyTo(stream);
                }

                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);

                }
                product.Image = fileName;
            }
            else
            {

                product.Image = oldproduct.Image;
            }
            // Category category=new Category() { Name= CategoryName };
            db.Dishes.Update(product);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult Delete(int Id)
        {
            var product = db.Dishes.Find(Id);
            // Category category=new Category() { Name= CategoryName };
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", product.Image);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);

            }

            db.Dishes.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
