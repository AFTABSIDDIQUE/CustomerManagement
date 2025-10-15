using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.Services;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult GetCustomerService(int id)
        {
            var data = services.GetCustomerServices(id);
            return Json(data);
        }

        [HttpPost]
        public IActionResult UpdateService(ServicePageViewModel model)
        {
            var data = model.UpdateService;
            if (data != null)
            {
                data.Updated = DateTime.Now;
                services.UpdateService(data);
                TempData["Success"] = "Service Updated successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to update service.";
            return View("Index", data);
        }
    }
}
