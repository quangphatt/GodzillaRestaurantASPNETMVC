using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface ITestimonialService
    {
        public IEnumerable<Testimonial> GetAllTestimonials();
        public Testimonial GetTestimonial(int id);
        public void AddTestimonial(Testimonial testimonial);
        public void UpdateTestimonial(Testimonial testimonial);
        public void DeleteTestimonial(int id);
    }
}
