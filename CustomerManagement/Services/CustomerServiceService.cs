using AutoMapper;
using CustomerManagement.Data;
using CustomerManagement.DTO.Customer;
using CustomerManagement.DTO.CustomerService;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Services
{
    public class CustomerServiceService : ICustomerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public CustomerServiceService(ApplicationDbContext db, IMapper mapper) 
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void AddCustomerService(AddCustomerServiceDTO data)
        {
            
            var details = mapper.Map<CustomerServices>(data);
            db.CustomerService.Add(details);
            db.SaveChanges();
        }

        public CustomersServices FetchCustomerService(int id)
        {
            var data =  db.Customer.FirstOrDefault(c => c.CustomerId == id);
            return data;

        }

        public List<FetchCustomerServiceDTO> FetchServiceList(int id)
        {
            var data = db.CustomerService.Include(x=>x.Customers).Include(s=>s.Services).Where(x=>x.CustomerId==id).ToList();
            var details = mapper.Map<List<FetchCustomerServiceDTO>>(data);
            return details;
        }

        public List<Service> FetchServiceListViewBag(int id)
        {
            return db.Service
    .Where(s => !db.CustomerService
        .Where(cs => cs.CustomerId == id)
        .Select(cs => cs.ServiceId)
        .Contains(s.ServiceId))
    .ToList();
        }

        public UpdateCustomerServiceDTO GetCustomerServices(int id)
        {
            var data = db.CustomerService.Include(c=>c.Customers).Include(s=>s.Services).FirstOrDefault(x => x.CustomerServicesId == id);
            var details = mapper.Map<UpdateCustomerServiceDTO>(data);
            return details;
        }

        public void UpdateCustomerDetails(UpdateCustomerDTO data)
        {
            var existingData = db.Customer.FirstOrDefault(x => x.CustomerId == data.CustomerId);
            if (existingData != null)
            {
                existingData.CustomerName = data.CustomerName;
                existingData.MobileNumber = data.MobileNumber;
                existingData.WhatsAppNumber = data.WhatsAppNumber;
                existingData.Reference = data.Reference;
                existingData.Email = data.Email;
                existingData.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
         }

        public void UpdateCustomerService(UpdateCustomerServiceDTO data)
        {
            var existingData = db.CustomerService.FirstOrDefault(x => x.CustomerServicesId == data.CustomerServicesId);
            if (existingData != null)
            {
                existingData.CustomerPrice = data.CustomerPrice;
                existingData.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
