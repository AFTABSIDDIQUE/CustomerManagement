namespace CustomerManagement.DTO.CustomerService
{
    public class UpdateCustomerServiceDTO
    {
        public int CustomerServicesId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal CustomerPrice { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
