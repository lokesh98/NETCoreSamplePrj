using Microsoft.AspNetCore.Mvc;

namespace Test_Core3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
