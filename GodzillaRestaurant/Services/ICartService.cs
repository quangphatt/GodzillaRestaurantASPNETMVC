using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface ICartService
    {
        public void AddToCart(int foodId);
        public void RemoveFromCart(int foodId);
        public List<CartItem> GetCartItems();
        public int GetTotalCart();
        public CartItem FindCartItem(int foodId);
        public List<CartItem> GetMenuCart();
    }
}
