using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GodzillaRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IChefService _chefService;
        private readonly ISpecialService _specialService;
        private readonly IEventService _eventService;
        private readonly ITestimonialService _testimonialService;
        private readonly IGalleryService _galleryService;
        private readonly IFoodService _foodService;
        private readonly IFoodTypeService _foodTypeService;
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IChefService chefService, ISpecialService specialService, IEventService eventService, ITestimonialService testialService, IGalleryService galleryService, IFoodService foodService, IFoodTypeService foodTypeService, ICartService cartService, IPaymentService paymentService, IOrderService orderService)
        {
            _logger = logger;
            _userManager = userManager;
            _chefService = chefService;
            _specialService = specialService;
            _eventService = eventService;
            _testimonialService = testialService;
            _galleryService = galleryService;
            _foodService = foodService;
            _foodTypeService = foodTypeService;
            _cartService = cartService;
            _paymentService = paymentService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("ADMIN"))
            {
                return Redirect("Admin");
            }
            ViewBag.Chefs = _chefService.GetAllChefs();
            ViewBag.Specials = _specialService.GetAllSpecials();
            ViewBag.Events = _eventService.GetAllEvents();
            ViewBag.Testimonials = _testimonialService.GetAllTestimonials();
            ViewBag.Gallery = _galleryService.GetAllGallery();
            ViewBag.Menu = _foodService.GetAllMenu();
            ViewBag.FoodType = _foodTypeService.GetAllFoodType();
            ViewBag.Cart = _cartService.GetCartItems();
            return View();
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/Menu")]
        public IActionResult Menu()
        {
            ViewBag.MenuCart = _cartService.GetMenuCart();
            ViewBag.FoodType = _foodTypeService.GetAllFoodType();
            return View();
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/Cart")]
        public IActionResult Cart()
        {
            ViewBag.Cart = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotalCart();
            return View();
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/CartAdd")]
        public IActionResult CartAdd(int foodId, int inMenu = 0)
        {
            _cartService.AddToCart(foodId);
            if (inMenu == 1) return RedirectToAction("Menu");
            return RedirectToAction("Cart");
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/CartRemove")]
        public IActionResult CartRemove(int foodId, int inMenu = 0)
        {
            _cartService.RemoveFromCart(foodId);
            if (inMenu == 1) return RedirectToAction("Menu");
            return RedirectToAction("Cart");
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/ViewOrder")]
        public IActionResult ViewOrder()
        {
            ViewBag.Cart = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotalCart();
            ViewBag.Payments = _paymentService.GetAllPayments();
            return View();
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/CheckOut")]
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _orderService.CheckOut(order);
            var _order = _orderService.GetOrder(order.OrderId);
            ViewBag.ItemOrders = _orderService.GetOrderItemByOrder(order.OrderId);
            return View(_order);
        }

        [Authorize(Roles = "CLIENT")]
        [Route("/AllOrder")]
        [HttpGet]
        public IActionResult AllOrder()
        {
            ViewBag.Orders = _orderService.GetAllOrdersOfUser();
            return View();
        }

        [Authorize(Roles = "CLIENT")]
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}