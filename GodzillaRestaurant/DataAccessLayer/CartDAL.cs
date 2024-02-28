using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class CartDAL : ICartService
    {
        private readonly AppDBContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public const string CARTKEY = "cart";

        public CartDAL(AppDBContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        public int GetTotalCart()
        {
            int total = 0;
            var cart = GetCartItems();
            foreach(CartItem item in cart)
            {
                total += item.Food.Price * item.Quantity;
            }
            return total;
        }

        public CartItem FindCartItem(int foodId)
        {
            var cart = GetCartItems();
            var cartItem = cart.Find(c => c.FoodId == foodId);
            if (cartItem == null)
            {
                Food food = _dbContext.Food.Find(foodId);
                return new CartItem(0, foodId, food);
            }
            return cartItem;
        }

        public List<CartItem> GetMenuCart()
        {
            var menu = _dbContext.Food.ToList();
            List<CartItem> cartItems = new List<CartItem>();
            for (var i = 0; i < menu.Count; i++)
            {
                cartItems.Add(FindCartItem(menu[i].FoodId));
            }
            return cartItems;
        }

        public void ClearCart()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            session.Remove(CARTKEY);
        }

        public void SaveCartSession(List<CartItem> ls)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public void AddToCart(int foodId)
        {
            Food food = _dbContext.Food.Find(foodId);
            if (food == null) return;

            var cart = GetCartItems();
            var cartItem = cart.Find(c => c.FoodId == foodId);
            if (cartItem != null)
            {
                // Exist => Increase 1
                cartItem.Quantity++;
            }
            else
            {
                // No exist => Add
                cart.Add(new CartItem(1, foodId, food));
            }

            SaveCartSession(cart);
        }

        public void RemoveFromCart(int foodId)
        {
            Food food = _dbContext.Food.Find(foodId);
            if (food == null) return;

            var cart = GetCartItems();
            var cartItem = cart.Find(c => c.FoodId == foodId);
            if (cartItem != null)
            {
                if (cartItem.Quantity == 1)
                {
                    cart.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity--;
                }
            }

            SaveCartSession(cart);
        }

        public void CheckOut()
        {

        }
    }
}
