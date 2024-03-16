using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaRestaurant.Controllers
{
    [Authorize(Roles = "CLIENT")]
    public class OrderController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;

        public OrderController(ICartService cartService, IOrderService orderService, IPaymentService paymentService)
        {
            _cartService = cartService;
            _orderService = orderService;
            _paymentService = paymentService;
        }

        [Route("/ViewOrder")]
        public IActionResult ViewOrder()
        {
            ViewBag.Cart = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotalCart();
            ViewBag.Payments = _paymentService.GetAllPayments();
            return View();
        }

        [Route("/CheckOut")]
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _orderService.CheckOut(order);
            var _order = _orderService.GetOrder(order.OrderId);
            ViewBag.ItemOrders = _orderService.GetOrderItemByOrder(order.OrderId);
            return View(_order);
        }

        [Route("/AllOrder")]
        [HttpGet]
        public IActionResult AllOrder()
        {
            ViewBag.Orders = _orderService.GetAllOrdersOfUser();
            return View();
        }

        [Route("/OrderDetail")]
        [HttpGet]
        public IActionResult OrderDetail(int id)
        {
            Order order = _orderService.GetOrder(id);
            if (order == null) return RedirectToAction("AllOrder");
            ViewBag.ItemOrders = _orderService.GetOrderItemByOrder(id);
            order.Payment = _paymentService.GetPayment(order.PaymentId);
            return View(order);
        }
    }
}
