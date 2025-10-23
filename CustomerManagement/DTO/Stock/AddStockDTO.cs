namespace CustomerManagement.DTO.Stores
{
    public class AddStockDTO
    {
        public string StockName { get; set; }
        public int HomeQuantity { get; set; }
        public int ShopQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
