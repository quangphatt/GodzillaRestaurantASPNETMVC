using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface ICartService
    {
        public void AddToCart(int foodId);
        public void RemoveFromCart(int foodId);
        public List<OrderItem> GetCartItems();
        public int GetTotalCart();
        public OrderItem FindCartItem(int foodId);
        public List<OrderItem> GetMenuCart();
    }
}
