using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.Services;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    public class ServiceController : Controller
    {
        private IServices services;
        public ServiceController(IServices services) 
        { 
            this.services = services;
        }
        public IActionResult Index()
        {
            var model = new ServicePageViewModel
            {
                FetchServices = services.FetchServices(),
                CreateService = new AddServiceDTO()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateService(ServicePageViewModel model)
        {
            var data = model.CreateService;
            if (data!=null)
            {
                data.CreatedAt = DateTime.Now;
                services.AddService(data);
                TempData["Success"] = "Service Added successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to create service.";
            return View("Index",data);
        }

    }
}
