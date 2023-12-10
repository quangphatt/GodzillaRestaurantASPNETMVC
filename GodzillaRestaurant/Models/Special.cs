using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Special
    {
        [Key]
        public int SpecialId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Introduction { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
    }
}
