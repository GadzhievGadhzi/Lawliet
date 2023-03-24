using Lawliet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lawliet.Controllers
{
    public class ProfileController : Controller {
        private readonly CachingService _cachingService;

        public ProfileController(CachingService cachingService) {
            _cachingService = cachingService;
        }

        public IActionResult Index() {
            return View();
        }
    }
}