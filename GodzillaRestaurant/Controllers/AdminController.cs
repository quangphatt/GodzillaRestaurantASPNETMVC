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
        private readonly ISpecialService _specialService;

        public AdminController(IChefService chefService, ISpecialService specialService)
        {
            _chefService = chefService;
            _specialService = specialService;
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

        // Manage Special
        public IActionResult Specials()
        {
            return View(_specialService.GetAllSpecials());
        }

        [HttpGet]
        public IActionResult CreateSpecial ()
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
    }
}
