using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodzillaRestaurant.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }
        public int Quantity { get; set; }
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }

        public CartItem(int quantity, int foodId, Food food)
        {
            Quantity = quantity;
            FoodId = foodId;
            Food = food;
        }
    }
}
