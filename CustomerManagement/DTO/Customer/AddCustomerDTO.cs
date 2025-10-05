namespace CustomerManagement.DTO.Customer
{
    public class AddCustomerDTO
    {
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string Reference { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
