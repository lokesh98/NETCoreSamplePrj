using Microsoft.AspNetCore.Mvc;
using Test_Core3.BusinessLayer.ViewModel;

namespace Test_Core3.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            // If ModelState is not valid, add a generic error message for each property.
            foreach (var property in typeof(StudentViewModel).GetProperties())
            {
                if (!ModelState.ContainsKey(property.Name))
                {
                    ModelState.AddModelError(property.Name, "This field is required.");
                }
            }
            return View(model);
        }
    }
}
