using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MgqsPollApp.Services.Interfaces;
using PollAppMGQS.Dtos;
namespace MgqsPollApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _loginService;
        public UserController(IUserService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CreateUserRequestModel model)
        {
            var user = await _loginService.Login(model);
            if (!user.Status)
            {
                return View(model);
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Data.DisplayName),
                new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Data.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
            return View(model);

        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "User");

        }
    }
}
