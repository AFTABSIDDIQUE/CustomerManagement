using CustomerManagement.DTO.Stock;
using CustomerManagement.DTO.Stores;
using CustomerManagement.Models;

namespace CustomerManagement.Repository
{
    public interface IStock
    {
        void AddStock(AddStockDTO data);
        IEnumerable<Stock> FetchStock();
        void UpdateStock(UpdateStockDTO data);
    }
}
