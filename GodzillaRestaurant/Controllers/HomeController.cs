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

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IChefService chefService)
        {
            _logger = logger;
            this._userManager = userManager;
            this._chefService = chefService;
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole("ADMIN"))
            {
                return Redirect("Admin");
            }
            ViewBag.Chefs = this._chefService.GetAllChefs();
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