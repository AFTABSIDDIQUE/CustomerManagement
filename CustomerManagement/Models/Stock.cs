using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int HomeQuantity { get; set; }
        public int ShopQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
