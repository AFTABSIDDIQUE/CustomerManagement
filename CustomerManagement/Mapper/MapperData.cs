using AutoMapper;
using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.CustomerService;
using CustomerManagement.DTO.Services;
using CustomerManagement.DTO.Stock;
using CustomerManagement.DTO.Stores;
using CustomerManagement.Models;

namespace CustomerManagement.Mapper
{
    public class MapperData:Profile
    {
        public MapperData() 
        {
            CreateMap<CustomersServices,AddCustomerDTO>().ReverseMap();
            CreateMap<CustomersServices, UpdateCustomerDTO>().ReverseMap();

            CreateMap<Service, AddServiceDTO>().ReverseMap();
            CreateMap<Service, FetchServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateCustomerServiceDTO>().ReverseMap();

            CreateMap<Stock, AddStockDTO>().ReverseMap();
            CreateMap<Stock, UpdateStockDTO>().ReverseMap();
            CreateMap<CustomerServices, AddCustomerServiceDTO>().ReverseMap();

            CreateMap<CustomerServices, FetchCustomerServiceDTO>().ForMember(x => x.CustomerName, x => x.MapFrom(x => x.Customers != null ? x.Customers.CustomerName : "No Data")).ForMember(x => x.ServiceName, x => x.MapFrom(x => x.Services != null ? x.Services.ServiceName : "No Data")).ForMember(x => x.MinimumPriceList, x => x.MapFrom(x => x.Services != null ? x.Services.MinimumPriceList : "No Data"));

            CreateMap<CustomerServices, UpdateCustomerServiceDTO>().ForMember(x => x.CustomerName, x => x.MapFrom(x => x.Customers != null ? x.Customers.CustomerName : "No Data")).ForMember(x => x.ServiceName, x => x.MapFrom(x => x.Services != null ? x.Services.ServiceName : "No Data"));

        }
    }
}
