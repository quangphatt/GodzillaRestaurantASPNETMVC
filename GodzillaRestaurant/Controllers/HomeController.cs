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

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IChefService chefService, ISpecialService specialService, IEventService eventService, ITestimonialService testialService, IGalleryService galleryService, IFoodService foodService, IFoodTypeService foodTypeService, ICartService cartService)
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