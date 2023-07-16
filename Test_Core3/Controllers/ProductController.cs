using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_Core3.BusinessLayer.Data;
using Test_Core3.BusinessLayer.Models;
using Test_Core3.BusinessLayer.ViewModel;

namespace Test_Core3.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include("Category");
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.Category = GetCategory();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {            
            ViewBag.Category = GetCategory();
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            foreach (var property in typeof(StudentViewModel).GetProperties())
            {
                if (!ModelState.ContainsKey(property.Name))
                {
                    ModelState.AddModelError(property.Name, "This field is required.");
                }
            }
            return View(product);
        }

        private List<SelectListItem> GetCategory()
        {
            var category = _context.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString(),
            }).ToList();
            category.Insert(0, new SelectListItem() { Text = "Select Category", Value = "" });
            return category;
        }
    }
}
