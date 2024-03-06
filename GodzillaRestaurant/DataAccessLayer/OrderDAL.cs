using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class OrderDAL : IOrderService
    {
        private AppDBContext _dbContext;
        private ICartService _cartService;
        private IPaymentService _paymentService;

        public OrderDAL(AppDBContext dbContext, ICartService cartService, IPaymentService paymentService)
        {
            _dbContext = dbContext;
            _cartService = cartService;
            _paymentService = paymentService;
        }

        public List<Order> GetAllOrders() => _dbContext.Order.ToList();

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
            order.OrderItems = _cartService.GetCartItems();
            order.CreatedDate = DateTime.Now;
            order.OrderStatus = 1;
            order.Payment = _paymentService.GetPayment(order.PaymentId);

            AddOrder(order);

            // Clear Cart
            _cartService.ClearCart();
        }
    }
}
