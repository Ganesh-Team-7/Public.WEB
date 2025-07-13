using Microsoft.AspNetCore.Mvc;
using Public.WEB.Models.Authentication;
using Public.WEB.Services.Authentication;

namespace Public.WEB.Controllers.Authentication
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid) return View(model);

            var token = await _accountService.LoginAsync(model);
            if (token != null)
            {
                HttpContext.Session.SetString("JWT", token);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login");
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (!ModelState.IsValid) return View(model);

            var success = await _accountService.RegisterAsync(model);
            if (success) return RedirectToAction("Login");

            ModelState.AddModelError("", "Failed to register");
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
