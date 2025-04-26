using Microsoft.AspNetCore.Mvc;
using Restaurant_Project.Data;
using Restaurant_Project.Models;

namespace Restaurant_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext db;


        public CategoryController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var categoryModel = db.Categories.ToList();
            return View(categoryModel);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {

            // Category category=new Category() { Name= CategoryName };
            db.Categories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int Id)
        {
            var category = db.Categories.Find(Id);
            return View(category);
        }



        [HttpPost]
        public IActionResult Edit(Category category)
        {

            // Category category=new Category() { Name= CategoryName };
            db.Categories.Update(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Category category)
        {

            // Category category=new Category() { Name= CategoryName };
            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

      