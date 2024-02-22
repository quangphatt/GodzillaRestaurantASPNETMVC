using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GodzillaRestaurant.Controllers
{
    [AllowAnonymous]
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

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IChefService chefService, ISpecialService specialService, IEventService eventService, ITestimonialService testialService, IGalleryService galleryService, IFoodService foodService, IFoodTypeService foodTypeService)
        {
            _logger = logger;
            this._userManager = userManager;
            this._chefService = chefService;
            this._specialService = specialService;
            this._eventService = eventService;
            this._testimonialService = testialService;
            this._galleryService = galleryService;
            this._foodService = foodService;
            this._foodTypeService = foodTypeService;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole("ADMIN"))
            {
                return Redirect("Admin");
            }
            ViewBag.Chefs = this._chefService.GetAllChefs();
            ViewBag.Specials = this._specialService.GetAllSpecials();
            ViewBag.Events = this._eventService.GetAllEvents();
            ViewBag.Testimonials = this._testimonialService.GetAllTestimonials();
            ViewBag.Gallery = this._galleryService.GetAllGallery();
            ViewBag.Menu = this._foodService.GetAllMenu();
            ViewBag.FoodType = this._foodTypeService.GetAllFoodType();
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