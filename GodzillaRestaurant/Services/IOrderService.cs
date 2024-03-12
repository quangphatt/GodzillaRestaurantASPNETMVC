
using GodzillaRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.Services
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetAllOrders();
        public IEnumerable<Order> GetAllOrdersOfUser();
        public Order GetOrder(int id);
        public void UpdateOrderStatus(int orderId, int orderStatus);
        public void CheckOut(Order order);
        public List<OrderItem> GetOrderItemByOrder(int orderId);
        public List<OrderItem> GetAllOrderItem();
    }
}
