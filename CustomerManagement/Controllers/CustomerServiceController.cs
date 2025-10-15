using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CustomerManagement.Controllers
{
    [Authorize]
    public class CustomerServiceController : Controller
    {
        private ICustomerHandler customerService;
        public CustomerServiceController(ICustomerHandler customerService)
        {
            this.customerService = customerService;
        }


        [HttpGet]
        public IActionResult Index(int id)
        {
            var data = customerService.FetchServiceList(id);

            var name = customerService.FetchCustomerService(id);
            ViewBag.CustomerInfo = new
            {
                Id = name.CustomerId,
                Name = name.CustomerName,
                Phone = name.MobileNumber,
                WhatsApp = name.WhatsAppNumber,
                Email = name.Email,
                Reference = name.Reference,
                LastVisited = name.CheckIn


            };


            var service = customerService.FetchServiceListViewBag(id);
            ViewBag.ServiceList = service.Select(s => new SelectListItem
            {
                Value = s.ServiceId.ToString(),
                Text = s.ServiceName
            }).ToList();

            // Replace null UpdatedAt with CreatedAt
            foreach (var dates in data)
            {
                if (dates.UpdatedAt == null)
                {
                    dates.UpdatedAt = dates.CreatedAt;
                }
            }

            var model = new CustomerServicePageModel
            {
                Services = data  // assuming CustomerServicePageModel has a property like List<FetchCustomerServiceDTO> Services
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerServicePageModel model)
        {
            var data = model.NewService;
            if (data != null) 
            {
                data.CreatedAt = DateTime.Now;
                customerService.AddCustomerService(data);
                TempData["Success"] = "Customer Services Added successfully!";
                return RedirectToAction("Index", new { id = data.CustomerId });
            }
            return View("Index", data);
        }

        [HttpGet]
        public IActionResult GetCustomerService(int id)
        {
            var data = customerService.GetCustomerServices(id);

            return Json(data);
        }

        [HttpPost]
        public IActionResult UpdateService(CustomerServicePageModel model)
        {
            var data = model.UpdateService;
            if (data != null)
            {
                customerService.UpdateCustomerService(data);
                TempData["Success"] = "Customer Services Updated successfully!";
                
            }
            return RedirectToAction("Index", new { id = data.CustomerId });
        }

        [HttpPost]
        public IActionResult UpdateCustomerInfo(CustomerServicePageModel model)
        {
            var data = model.UpdateCustomer;
            if (data != null)
            {
                data.UpdatedAt = DateTime.Now;
                customerService.UpdateCustomerDetails(data);
                TempData["Success"] = "Customer Info Updated successfully!";
                
            }
            return RedirectToAction("Index", new { id = data.CustomerId });
        }

        [HttpPost]
        public IActionResult CheckInCustomer(int customerId)
        {
            if (customerId > 0)
            {
                customerService.CheckInCustomer(customerId);
                return Json(new { success = true, message = "Customer checked in successfully!" });
            }

            return Json(new { success = false, message = "Invalid Customer ID!" });
        }

    }
}
