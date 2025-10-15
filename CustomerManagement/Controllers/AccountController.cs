using CustomerManagement.DTO.Account;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogin _authService;
        public AccountController(ILogin authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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
