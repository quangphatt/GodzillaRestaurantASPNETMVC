using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GodzillaRestaurant.Controllers
{
	[Authorize(Roles = "CLIENT")]
	public class BookingController : Controller
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateBooking(Booking booking)
		{
			_bookingService.CreateBooking(booking);
			return RedirectToAction("CheckOut");
		}

		[Route("/AllBooking")]
		public IActionResult AllBooking()
		{
			return View(_bookingService.GetAllBookingOfUser());
		}

		public IActionResult CheckOut()
		{
			return View();
		}
	}
}