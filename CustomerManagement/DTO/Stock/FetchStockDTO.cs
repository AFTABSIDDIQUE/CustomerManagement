namespace CustomerManagement.DTO.Stock
{
    public class FetchStockDTO
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public int HomeQuantity { get; set; }
        public int ShopQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
