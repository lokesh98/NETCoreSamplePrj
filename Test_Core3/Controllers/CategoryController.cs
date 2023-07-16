using Microsoft.AspNetCore.Mvc;
using Test_Core3.BusinessLayer.Data;
using Test_Core3.BusinessLayer.Models;

namespace Test_Core3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            TempData["success"] = "Data loaded successfully";
            var category =_context.Categories.ToList();
            return View(category);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            ModelState.Remove("Products");
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
