using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.CustomerService;
using CustomerManagement.Models;

namespace CustomerManagement.Repository
{
    public interface ICustomerHandler
    {
        CustomersServices FetchCustomerService(int id);

        List<FetchCustomerServiceDTO> FetchServiceList(int id);
        public void AddCustomerService(AddCustomerServiceDTO data);
        List<Service> FetchServiceListViewBag(int id);
        UpdateCustomerServiceDTO GetCustomerServices(int id);
        public void UpdateCustomerService(UpdateCustomerServiceDTO data);
        public void UpdateCustomerDetails(UpdateCustomerDTO data);
        public void CheckInCustomer(int id);
    }
}
