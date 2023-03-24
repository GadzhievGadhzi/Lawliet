using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Lawliet.Models;
using Lawliet.Services;

namespace Lawliet.Controllers {
    public class AuthController : Controller {
        private readonly CachingService _cachingService;

        public AuthController(CachingService cachingService) {
            _cachingService = cachingService;
        }

        public async Task Login() {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties() {
                RedirectUri = Url.Action("loggedIn")
            });
        }

        public async Task<IActionResult> LoggedIn() {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claim = result?.Principal?.Identities?.FirstOrDefault()?.Claims.Select(claim => new {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });

            var user = new User();
            claim?.ToList().ForEach(x => {
                switch (x.Type) {
                    case ClaimTypes.NameIdentifier:
                        user.Id = x.Value;
                        break;

                    case ClaimTypes.Name:
                        user.Name = x.Value;
                        break;

                    case ClaimTypes.Email:
                        user.Email = x.Value;
                        break;

                    case "urn:google:picture":
                        user.PictureUrl = x.Value;
                        break;
                }
            });

            await _cachingService.AddObjectFromCache(user);
            HttpContext.Response.Cookies.Append("id", user.Id);
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("id");
            return RedirectToAction("index", "home");
        }

        /*[HttpGet] public IActionResult LoginConfirmation() => View();

        [HttpPost]
        public IActionResult LoginConfirmation(bool isClickedLoginButton) {
            if (isClickedLoginButton) {
                return RedirectToAction("login", "auth");
            }
            return RedirectToAction("index", "home");
        }*/
    }
}