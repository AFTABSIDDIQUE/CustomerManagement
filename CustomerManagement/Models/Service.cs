using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string MinimumPriceList {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<CustomerServices> CustomerServices { get; set; }
    }
}
