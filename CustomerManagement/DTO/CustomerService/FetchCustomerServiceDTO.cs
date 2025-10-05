using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.DTO.CustomerService
{
    public class FetchCustomerServiceDTO
    {
        public int CustomerServicesId { get; set; }
        public string CustomerName { get; set; }
        public string ServiceName { get; set; }
        public decimal CustomerPrice { get; set; }
        public decimal MinimumPriceList { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
