using CustomerManagement.DTO.Stock;
using CustomerManagement.DTO.Stores;
namespace CustomerManagement.Models
{
    public class StockPageViewModel
    {
        public IEnumerable<Stock> FetchStocks { get; set; }
        public AddStockDTO AddNewStock { get; set; }
        public UpdateStockDTO UpdateStock { get; set; }
    }
}
