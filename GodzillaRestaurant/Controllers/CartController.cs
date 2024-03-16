using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaRestaurant.Controllers
{
    [Authorize(Roles = "CLIENT")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            ViewBag.Cart = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotalCart();
            return View();
        }

        public IActionResult Add(int foodId, int inMenu = 0)
        {
            _cartService.AddToCart(foodId);
            if (inMenu == 1) return RedirectToAction("Menu", "Home");
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int foodId, int inMenu = 0)
        {
            _cartService.RemoveFromCart(foodId);
            if (inMenu == 1) return RedirectToAction("Menu", "Home");
            return RedirectToAction("Index");
        }
    }
}
