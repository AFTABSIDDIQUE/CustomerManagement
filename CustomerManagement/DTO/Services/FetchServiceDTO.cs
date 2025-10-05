namespace CustomerManagement.DTO.Services
{
    public class FetchServiceDTO
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string MinimumPriceList { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
