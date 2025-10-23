using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.Stores;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    public class StockController : Controller
    {
        private readonly IStock stocks;
        public StockController(IStock stocks)
        {
            this.stocks = stocks;
        }
        public IActionResult Index()
        {
            var model = new StockPageViewModel
            {
                FetchStocks = stocks.FetchStock()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddStock(StockPageViewModel model)
        {
            var data = model.AddNewStock;
            if(data!= null)
            {
                stocks.AddStock(data);
                TempData["Success"] = "Stock added successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to add stock. Please try again.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateStock(StockPageViewModel model)
        {
            var data = model.UpdateStock;
            if(data != null)
            {
                stocks.UpdateStock(data);
                TempData["Success"] = "Stock updated successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to update stock. Please try again.";
            return RedirectToAction("Index");
        }
    }
}
