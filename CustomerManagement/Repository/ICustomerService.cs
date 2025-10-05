using CustomerManagement.DTO.CustomerService;
using CustomerManagement.Models;

namespace CustomerManagement.Repository
{
    public interface ICustomerService
    {
        CustomersServices FetchCustomerService(int id);

        List<FetchCustomerServiceDTO> FetchServiceList(int id);
        public void AddCustomerService(AddCustomerServiceDTO data);
        List<Service> FetchServiceListViewBag(int id);
    }
}
