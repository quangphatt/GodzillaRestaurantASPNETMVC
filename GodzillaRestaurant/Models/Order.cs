using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OrderStatus { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PaymentType { get; set; }
    }
}
