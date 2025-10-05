using CustomerManagement.DTO.Customer;
using CustomerManagement.Models;

namespace CustomerManagement.Repository
{
    public interface ICustomer
    {
        void AddCustomer(AddCustomerDTO data);
        IEnumerable<CustomersServices> FetchCustomers();
    }
}
