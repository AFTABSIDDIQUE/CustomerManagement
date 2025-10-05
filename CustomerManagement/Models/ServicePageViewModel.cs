using CustomerManagement.DTO.Services;

namespace CustomerManagement.Models
{
    public class ServicePageViewModel
    {
        public IEnumerable<Service> FetchServices { get; set; }
        public AddServiceDTO CreateService { get; set; }
    }
}
