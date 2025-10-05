using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.Models
{
    public class CustomerServices
    {
        [Key]
        public int CustomerServicesId { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public decimal CustomerPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [ForeignKey("CustomerId")]
        public CustomersServices Customers { get; set; }

        [ForeignKey("ServiceId")]
        public Service Services { get; set; }
    }
}
