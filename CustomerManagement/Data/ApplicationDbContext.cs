using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CustomersServices>Customer { get; set; }
        public DbSet<Service>Service { get; set; }
        public DbSet<CustomerServices> CustomerService { get; set; }
        public DbSet<Accounts> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerServices>()
                .HasOne(c => c.Customers)
                .WithMany(cs => cs.CustomerServices)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerServices>()
                .HasOne(s => s.Services)
                .WithMany(cs => cs.CustomerServices)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);               
                                

        }

    }
}
