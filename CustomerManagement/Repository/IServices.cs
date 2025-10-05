using CustomerManagement.DTO.Services;
using CustomerManagement.Models;

namespace CustomerManagement.Repository
{
    public interface IServices
    {
        IEnumerable<Service> FetchServices();
        void AddService(AddServiceDTO data);
    }
}
