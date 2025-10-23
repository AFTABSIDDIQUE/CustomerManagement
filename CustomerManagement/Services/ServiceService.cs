using AutoMapper;
using CustomerManagement.Data;
using CustomerManagement.DTO.Services;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CustomerManagement.Services
{
    public class ServiceService : IServices
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public ServiceService(ApplicationDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        
        public void AddService(AddServiceDTO data)
        {
            var details = mapper.Map<Service>(data);
            db.Service.Add(details);
            db.SaveChanges();

        }

        public IEnumerable<Service> FetchServices()
        {
            return db.Service.ToList();
        }

        public UpdateServiceDTO GetCustomerServices(int id)
        {
            var details = db.Service.Find(id);
            var data = mapper.Map<UpdateServiceDTO>(details);
            return data;   
        }

        public void UpdateService(UpdateServiceDTO data)
        {
            var existingService = db.Service.Find(data.ServiceId);
            if (existingService != null)
            {
                // Update the fields based on the DTO
                existingService.ServiceName = data.ServiceName;
                existingService.MinimumPriceList = data.MinimumPriceList;
                existingService.UpdatedAt = DateTime.UtcNow; // Optional: for audit tracking

                // Save changes to the database
                db.SaveChanges();
            }

        }
    }
}
