using System.Diagnostics;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDashboard dashboardData;

        public HomeController(ILogger<HomeController> logger,IDashboard dashboardData)
        {
            _logger = logger;
            this.dashboardData = dashboardData;
        }

        public IActionResult Index(DashboardData data)
        {
            int customerCount = dashboardData.GetCustomerCount();   
            int serviceCount = dashboardData.GetServiceCount();
            data.CustomerCount = customerCount;
            data.ServiceCount = serviceCount;
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWTToken");

            return RedirectToAction("Index", "Account");
        }
    }

}
