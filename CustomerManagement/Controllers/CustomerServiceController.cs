using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CustomerManagement.Controllers
{
    public class CustomerServiceController : Controller
    {
        private ICustomerService customerService;
        public CustomerServiceController(ICustomerService customerService)
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
                Name = name.CustomerName
            };


            var service = customerService.FetchServiceListViewBag(id);
            ViewBag.ServiceList = service.Select(s => new SelectListItem
            {
                Value = s.ServiceId.ToString(),
                Text = s.ServiceName
            }).ToList();

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
                customerService.AddCustomerService(data);
                TempData["Success"] = "Customer Services Added successfully!";
                return RedirectToAction("Index", new { id = data.CustomerId });
            }
            return View("Index", data);
        }



    }
}
