using Lawliet.Data;
using Lawliet.Models;
using Lawliet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lawliet.Controllers
{
    public class ProfileController : Controller {
        private readonly UserDataContext _context;
        private readonly CachingService _cachingService;

        public ProfileController(UserDataContext context, CachingService cachingService) {
            _context = context;
            _cachingService = cachingService;
        }

        public IActionResult Index() {
            DataRepository<User> repository = new DataRepository<User>(_context);
            var user = repository.GetWithInclude(x => x.Id == HttpContext.Request.Cookies["id"], z => z.Topics).ToList();
            return View(user.FirstOrDefault());
        }
    }
}