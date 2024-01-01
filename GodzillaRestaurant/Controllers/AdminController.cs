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
        private readonly IEventService _eventService;
        private readonly ITestimonialService _testimonialService;
        private readonly IGalleryService _galleryService;

        public AdminController(IChefService chefService, ISpecialService specialService, IEventService eventService, ITestimonialService testimonialService, IGalleryService galleryService)
        {
            _chefService = chefService;
            _specialService = specialService;
            _eventService = eventService;
            _testimonialService = testimonialService;
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
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
    }
}
