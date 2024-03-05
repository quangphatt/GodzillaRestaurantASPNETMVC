using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class OrderItem
    {
        [Key]
        public string OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public OrderItem(int foodId, int quantity)
        {
            this.Quantity = quantity;
            this.FoodId = foodId;
        }
    }
}
