using CustomerManagement.DTO.Customer;
using CustomerManagement.Repository;

namespace CustomerManagement.Models
{
    public class CustomerPageViewModel
    {
        public IEnumerable<CustomersServices> Customers { get; set; }
        public AddCustomerDTO NewCustomer { get; set; }
    }
}
