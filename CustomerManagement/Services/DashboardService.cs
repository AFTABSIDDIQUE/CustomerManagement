using CustomerManagement.Data;
using CustomerManagement.Repository;

namespace CustomerManagement.Services
{
    public class DashboardService : IDashboard
    {
        private ApplicationDbContext db;
        public DashboardService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int GetCustomerCount()
        {
            int data = db.Customer.Count();
            return data;
        }

        public int GetServiceCount()
        {
            int data = db.Service.Count();
            return data;
        }

        public string GetUserName(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
