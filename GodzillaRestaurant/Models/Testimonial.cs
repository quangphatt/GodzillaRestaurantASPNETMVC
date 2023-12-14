using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Testimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
    }
}
