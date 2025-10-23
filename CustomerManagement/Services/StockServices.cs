using AutoMapper;
using CustomerManagement.Data;
using CustomerManagement.DTO.Stock;
using CustomerManagement.DTO.Stores;
using CustomerManagement.Models;
using CustomerManagement.Repository;

namespace CustomerManagement.Services
{
    public class StockServices:IStock
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper; 
        public StockServices(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddStock(AddStockDTO data)
        {
            data.CreatedAt= DateTime.Now;
            var details = mapper.Map<Stock>(data);
            db.Stocks.Add(details);
            db.SaveChanges();
        }

        public IEnumerable<Stock> FetchStock()
        {
            var data = db.Stocks.ToList();
            return data;
        }

        public void UpdateStock(UpdateStockDTO data)
        {
            var details = db.Stocks.FirstOrDefault(x => x.StockId == data.StockId);

            if (details != null)
            {
                // 2. Map the updated fields from data to the existing entity
                mapper.Map(data, details);  // note: source=data, destination=details

                // 3. Save changes
                db.SaveChanges();
            }
        }
    }
}
