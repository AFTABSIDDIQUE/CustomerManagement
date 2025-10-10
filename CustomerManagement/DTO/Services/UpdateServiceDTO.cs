namespace CustomerManagement.DTO.Services
{
    public class UpdateServiceDTO
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string MinimumPriceList { get; set; }
        public DateTime Updated { get; set; }
    }
}
