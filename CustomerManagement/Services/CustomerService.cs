using AutoMapper;
using CustomerManagement.Data;
using CustomerManagement.DTO.Customer;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerManagement.Services
{
    public class CustomerService: ICustomer
    {
        private ApplicationDbContext db;
        private IMapper mapper;

        public CustomerService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void AddCustomer(AddCustomerDTO data)
        {
            var details = mapper.Map<CustomersServices>(data);
            db.Customer.Add(details);
            db.SaveChanges();
        }

        public IEnumerable<CustomersServices> FetchCustomers()
        {
            
            return db.Customer.ToList(); ;
        }
    }
}
