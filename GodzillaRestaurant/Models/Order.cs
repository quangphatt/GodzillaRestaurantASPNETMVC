using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodzillaRestaurant.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderStatus { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public int Total { get; set; }
    }
}
