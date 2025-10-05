using AutoMapper;
using CustomerManagement.Data;
using CustomerManagement.DTO.Services;
using CustomerManagement.Models;
using CustomerManagement.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CustomerManagement.Services
{
    public class ServiceService:IServices
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
    }
}
