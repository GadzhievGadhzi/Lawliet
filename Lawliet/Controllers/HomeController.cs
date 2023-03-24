using Microsoft.AspNetCore.Mvc;

namespace Lawliet.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}