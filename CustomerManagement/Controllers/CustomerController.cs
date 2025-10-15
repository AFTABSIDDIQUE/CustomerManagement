using CustomerManagement.DTO.Customer;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ICustomer customerService;
        
        public CustomerController(ICustomer customerService)
        {
            this.customerService = customerService;
        }
        public IActionResult Index()
        {
            var model = new CustomerPageViewModel
            {
                Customers = customerService.FetchCustomers(),
                NewCustomer = new AddCustomerDTO()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCustomer(CustomerPageViewModel model)
        {
            var data = model.NewCustomer;

            if (data!=null)
            {
                data.CreatedAt = DateTime.Now;
                data.CheckIn = DateTime.Now;
                customerService.AddCustomer(data);
                TempData["Success"] = "Customer Added successfully!";
                return RedirectToAction("Index");
            }

            model.Customers = customerService.FetchCustomers();
            return View("Index", model);
        }


    }
}
