using CustomerManagement.DTO.Account;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ILogin _authService;
        public AccountController(ILogin authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserData data)
        {
            var token = await _authService.LoginAsync(data);
            if (token == null)
            {
                TempData["Error"] = "Invalid username or password.";
                return RedirectToAction("Index", "Account");
            }
            TempData["Success"] = "Login Successfully...";

            HttpContext.Session.SetString("JWTToken", token);
            //HttpContext.Session.SetString("JWTToken", token);

            return RedirectToAction("Index", "Home",new {username = data.UserName});
        }
    }
}
