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

        public List<OrderItem> GetCartItems()
        {
            var session = _httpContextAccessor.HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<OrderItem>>(jsoncart);
            }
            return new List<OrderItem>();
        }

        public int GetTotalCart()
        {
            int total = 0;
            var cart = GetCartItems();
            foreach (OrderItem item in cart)
            {
                total += item.Food.Price * item.Quantity;
            }
            return total;
        }

        public OrderItem FindCartItem(int foodId)
        {
            var cart = GetCartItems();
            var cartItem = cart.Find(c => c.FoodId == foodId);
            if (cartItem == null)
            {
                Food food = _dbContext.Food.Find(foodId);
                return CreateOrderItem(foodId, 0);
            }
            return cartItem;
        }

        public OrderItem CreateOrderItem(int foodId, int quantity)
        {
            Food food = _dbContext.Food.Find(foodId);
            OrderItem orderItem = new OrderItem(foodId, quantity);
            orderItem.Food = food;
            return orderItem;
        }

        public List<OrderItem> GetMenuCart()
        {
            var menu = _dbContext.Food.ToList();
            List<OrderItem> cartItems = new List<OrderItem>();
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

        public void SaveCartSession(List<OrderItem> ls)
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
                cart.Add(CreateOrderItem(foodId, 1));
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
    }
}
