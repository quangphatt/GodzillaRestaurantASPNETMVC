using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class OrderDAL : IOrderService
    {
        private readonly AppDBContext _dbContext;
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IFoodService _foodService;
        private readonly IUserService _userService;

        public OrderDAL(AppDBContext dbContext, ICartService cartService, IPaymentService paymentService, IFoodService foodService, IUserService userService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _paymentService = paymentService;
            _foodService = foodService;
            _userService = userService;
        }

        public IEnumerable<Order> GetAllOrders() => _dbContext.Order.OrderByDescending(o => o.CreatedDate).ToList();

        public IEnumerable<Order> GetAllOrdersOfUser() => _dbContext.Order.Where(o => o.UserId == _userService.GetUserId()).OrderByDescending(o => o.CreatedDate);

        public Order GetOrder(int id) => _dbContext.Order.Find(id);

        public void AddOrder(Order order)
        {
            try
            {
                _dbContext.Order.Add(order);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            try
            {
                _dbContext.OrderItem.Add(orderItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<OrderItem> GetOrderItemByOrder(int orderId)
        {
            var listOrderItem = _dbContext.OrderItem.Where(o => o.OrderId == orderId).ToList();
            foreach (OrderItem orderItem in listOrderItem)
            {
                var food = _foodService.GetFood(orderItem.FoodId);
                orderItem.Food = food;
            }
            return listOrderItem;
        }

        public List<OrderItem> GetAllOrderItem()
        {
            var listOrderItem = _dbContext.OrderItem.ToList();
            foreach (OrderItem orderItem in listOrderItem)
            {
                var food = _foodService.GetFood(orderItem.FoodId);
                orderItem.Food = food;
            }
            return listOrderItem;
        }

        public void UpdateOrderStatus(int orderId, int orderStatus)
        {
            try
            {
                var order = GetOrder(orderId);
                order.OrderStatus = orderStatus;
                _dbContext.Entry(order).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void CheckOut(Order order)
        {
            var cartItems = _cartService.GetCartItems();
            order.CreatedDate = DateTime.UtcNow;
            order.OrderStatus = 1;
            order.Payment = _paymentService.GetPayment(order.PaymentId);
            order.Total = _cartService.GetTotalCart();
            order.UserId = _userService.GetUserId();

            // Add Order
            AddOrder(order);

            // Add OrderItems
            foreach (var item in cartItems)
            {
                item.OrderId = order.OrderId;
                item.Food = null;
                AddOrderItem(item);
            }

            // Clear Cart
            _cartService.ClearCart();
        }
    }
}
