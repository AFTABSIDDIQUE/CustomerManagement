using CustomerManagement.DTO.CustomerService;

namespace CustomerManagement.Models
{
    public class CustomerServicePageModel
    {
        public IEnumerable<FetchCustomerServiceDTO> Services { get; set; }
        public AddCustomerServiceDTO NewService { get; set; } 
        public UpdateCustomerServiceDTO UpdateService { get; set; }
    }
}
