using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GodzillaRestaurant.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly IChefService _chefService;
        private readonly ISpecialService _specialService;
        private readonly IEventService _eventService;
        private readonly ITestimonialService _testimonialService;
        private readonly IGalleryService _galleryService;
        private readonly IFoodService _foodService;
        private readonly IFoodTypeService _foodTypeService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IBookingService _bookingService;
        private readonly ManageItem[] _manageItems = new ManageItem[10];

        public AdminController(IChefService chefService, ISpecialService specialService, IEventService eventService, ITestimonialService testimonialService, IGalleryService galleryService, IFoodService foodService, IFoodTypeService foodTypeService, IPaymentService paymentService, IOrderService orderService, IBookingService bookingService)
        {
            _chefService = chefService;
            _specialService = specialService;
            _eventService = eventService;
            _testimonialService = testimonialService;
            _galleryService = galleryService;
            _foodService = foodService;
            _foodTypeService = foodTypeService;
            _paymentService = paymentService;
            _orderService = orderService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            _manageItems[0] = new ManageItem("Chefs", _chefService.GetAllChefs().Count(), "user");
            _manageItems[1] = new ManageItem("Specials", _specialService.GetAllSpecials().Count(), "fire");
            _manageItems[2] = new ManageItem("Events", _eventService.GetAllEvents().Count(), "calendar-days");
            _manageItems[3] = new ManageItem("Testimonials", _testimonialService.GetAllTestimonials().Count(), "comment-dots");
            _manageItems[4] = new ManageItem("Gallery", _galleryService.GetAllGallery().Count(), "images");
            _manageItems[5] = new ManageItem("Menu", _foodService.GetAllMenu().Count(), "burger");
            _manageItems[6] = new ManageItem("FoodType", _foodTypeService.GetAllFoodType().Count(), "bowl-food");
            _manageItems[7] = new ManageItem("Payment", _paymentService.GetAllPayments().Count(), "credit-card");
            _manageItems[8] = new ManageItem("Order", _orderService.GetAllOrders().Count(), "rectangle-list");
            _manageItems[9] = new ManageItem("Booking", _bookingService.GetAllBooking().Count(), "calendar-minus");
            ViewBag.ManageItems = _manageItems;
            return View();
        }

        // Manage Chefs
        public IActionResult Chefs()
        {
            return View(_chefService.GetAllChefs());
        }

        [HttpGet]
        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _chefService.AddChef(chef);
            return RedirectToAction("Chefs");
        }

        [HttpGet]
        public IActionResult EditChef(int id)
        {
            Chef chef = _chefService.GetChef(id);
            if (chef == null) return RedirectToAction("Chefs");
            else return View(chef);
        }

        [HttpPost]
        public IActionResult EditChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                _chefService.UpdateChef(chef);
                return RedirectToAction("Chefs");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteChef(int id)
        {
            Chef chef = _chefService.GetChef(id);
            if (chef == null) return RedirectToAction("Chefs");
            else return View(chef);
        }

        [HttpPost]
        public IActionResult DeleteChef(Chef chef)
        {
            _chefService.DeleteChef(chef.ChefId);
            return RedirectToAction("Chefs");
        }

        // Manage Specials
        public IActionResult Specials()
        {
            return View(_specialService.GetAllSpecials());
        }

        [HttpGet]
        public IActionResult CreateSpecial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSpecial(Special special)
        {
            _specialService.AddSpecial(special);
            return RedirectToAction("Specials");
        }

        [HttpGet]
        public IActionResult EditSpecial(int id)
        {
            Special special = _specialService.GetSpecial(id);
            if (special == null) return RedirectToAction("Specials");
            else return View(special);
        }

        [HttpPost]
        public IActionResult EditSpecial(Special special)
        {
            if (ModelState.IsValid)
            {
                _specialService.UpdateSpecial(special);
                return RedirectToAction("Specials");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteSpecial(int id)
        {
            Special special = _specialService.GetSpecial(id);
            if (special == null) return RedirectToAction("Specials");
            else return View(special);
        }

        [HttpPost]
        public IActionResult DeleteSpecial(Special special)
        {
            _specialService.DeleteSpecial(special.SpecialId);
            return RedirectToAction("Specials");
        }

        // Manage Events
        public IActionResult Events()
        {
            return View(_eventService.GetAllEvents());
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEvent(Event _event)
        {
            _eventService.AddEvent(_event);
            return RedirectToAction("Events");
        }

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            Event _event = _eventService.GetEvent(id);
            if (_event == null) return RedirectToAction("Events");
            else return View(_event);
        }

        [HttpPost]
        public IActionResult EditEvent(Event _event)
        {
            if (ModelState.IsValid)
            {
                _eventService.UpdateEvent(_event);
                return RedirectToAction("Events");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEvent(int id)
        {
            Event _event = _eventService.GetEvent(id);
            if (_event == null) return RedirectToAction("Events");
            else return View(_event);
        }

        [HttpPost]
        public IActionResult DeleteEvent(Event _event)
        {
            _eventService.DeleteEvent(_event.EventId);
            return RedirectToAction("Events");
        }

        // Manage Testimonials
        public IActionResult Testimonials()
        {
            return View(_testimonialService.GetAllTestimonials());
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _testimonialService.AddTestimonial(testimonial);
            return RedirectToAction("Testimonials");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            Testimonial testimonial = _testimonialService.GetTestimonial(id);
            if (testimonial == null) return RedirectToAction("Testimonials");
            else return View(testimonial);
        }

        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _testimonialService.UpdateTestimonial(testimonial);
                return RedirectToAction("Testimonials");
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteTestimonial(int id)
        {
            Testimonial testimonial = _testimonialService.GetTestimonial(id);
            if (testimonial == null) return RedirectToAction("Testimonials");
            else return View(testimonial);
        }

        [HttpPost]
        public IActionResult DeleteTestimonial(Testimonial testimonial)
        {
            _testimonialService.DeleteTestimonial(testimonial.TestimonialId);
            return RedirectToAction("Testimonials");
        }

        // Manage Gallery
        public IActionResult Gallery()
        {
            return View(_galleryService.GetAllGallery());
        }

        [HttpGet]
        public IActionResult CreateGalleryItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateGalleryItem(GalleryItem galleryItem)
        {
            _galleryService.AddGalleryItem(galleryItem);
            return RedirectToAction("Gallery");
        }

        [HttpGet]
        public IActionResult DeleteGalleryItem(int id)
        {
            GalleryItem galleryItem = _galleryService.GetGalleryItem(id);
            if (galleryItem == null) return RedirectToAction("Gallery");
            else return View(galleryItem);
        }

        [HttpPost]
        public IActionResult DeleteGalleryItem(GalleryItem galleryItem)
        {
            _galleryService.DeleteGalleryItem(galleryItem.GalleryItemId);
            return RedirectToAction("Gallery");
        }

        // Manage Food
        public IActionResult Menu()
        {
            return View(_foodService.GetAllMenu());
        }

        [HttpGet]
        public IActionResult CreateFood()
        {
            ViewBag.FoodTypeId = new SelectList(_foodTypeService.GetAllFoodType(), "FoodTypeId", "FoodTypeName", 0);
            return View();
        }

        [HttpPost]
        public IActionResult CreateFood(Food food)
        {
            _foodService.AddFood(food);
            return RedirectToAction("Menu");
        }

        [HttpGet]
        public IActionResult EditFood(int id)
        {
            Food food = _foodService.GetFood(id);
            if (food == null) return RedirectToAction("Menu");
            else
            {
                ViewBag.FoodTypeId = new SelectList(_foodTypeService.GetAllFoodType(), "FoodTypeId", "FoodTypeName", food.FoodTypeId);
                return View(food);
            }
        }

        [HttpPost]
        public IActionResult EditFood(Food food)
        {
            ViewBag.FoodTypeId = new SelectList(_foodTypeService.GetAllFoodType(), "FoodTypeId", "FoodTypeName", food.FoodTypeId);
            _foodService.UpdateFood(food);
            return RedirectToAction("Menu");
        }

        [HttpGet]
        public IActionResult DeleteFood(int id)
        {
            Food food = _foodService.GetFood(id);
            if (food == null) return RedirectToAction("Menu");
            else return View(food);
        }

        [HttpPost]
        public IActionResult DeleteFood(Food food)
        {
            _foodService.DeleteFood(food.FoodId);
            return RedirectToAction("Menu");
        }

        // Manage Food Type
        public IActionResult FoodType()
        {
            return View(_foodTypeService.GetAllFoodType());
        }

        [HttpGet]
        public IActionResult CreateFoodType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFoodType(FoodType foodType)
        {
            _foodTypeService.AddFoodType(foodType);
            return RedirectToAction("FoodType");
        }

        [HttpGet]
        public IActionResult DeleteFoodType(int id)
        {
            FoodType foodType = _foodTypeService.GetFoodType(id);
            if (foodType == null) return RedirectToAction("FoodType");
            else return View(foodType);
        }

        [HttpPost]
        public IActionResult DeleteFoodType(FoodType foodType)
        {
            _foodTypeService.DeleteFoodType(foodType.FoodTypeId);
            return RedirectToAction("FoodType");
        }

        // Manage Payment
        public IActionResult Payment()
        {
            return View(_paymentService.GetAllPayments());
        }

        [HttpGet]
        public IActionResult CreatePayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePayment(Payment payment)
        {
            _paymentService.AddPayment(payment);
            return RedirectToAction("Payment");
        }

        [HttpGet]
        public IActionResult EditPayment(int id)
        {
            Payment payment = _paymentService.GetPayment(id);
            if (payment == null) return RedirectToAction("Payment");
            else return View(payment);
        }

        [HttpPost]
        public IActionResult EditPayment(Payment payment)
        {
            _paymentService.UpdatePayment(payment);
            return RedirectToAction("Payment");
        }

        [HttpGet]
        public IActionResult DeletePayment(int id)
        {
            Payment payment = _paymentService.GetPayment(id);
            if (payment == null) return RedirectToAction("Payment");
            else return View(payment);
        }

        [HttpPost]
        public IActionResult DeletePayment(Payment payment)
        {
            _paymentService.DeletePayment(payment.PaymentId);
            return RedirectToAction("Payment");
        }

        // Manage Order
        public IActionResult Order()
        {
            return View(_orderService.GetAllOrders());
        }

        public IActionResult OrderDetail(int id)
        {
            Order order = _orderService.GetOrder(id);
            if (order == null) return RedirectToAction("AllOrder");
            ViewBag.ItemOrders = _orderService.GetOrderItemByOrder(id);
            order.Payment = _paymentService.GetPayment(order.PaymentId);
            return View(order);
        }

        public IActionResult ChangeOrderStatus(int orderId, int orderStatus)
        {
            _orderService.UpdateOrderStatus(orderId, orderStatus);
            return RedirectToAction("Order");
        }

        // Manage Booking
        public IActionResult Booking()
        {
            return View(_bookingService.GetAllBooking());
        }

        public IActionResult ChangeBookingStatus(int bookingId, int bookingStatus)
        {
            _bookingService.UpdateBookingStatus(bookingId, bookingStatus);
            return RedirectToAction("Booking");
        }
    }
}
