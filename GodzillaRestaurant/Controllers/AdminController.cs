using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaRestaurant.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly IChefService _chefService;

        public AdminController(IChefService chefService)
        {
            _chefService = chefService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Manage Chef
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
    }
}
