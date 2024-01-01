using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        public string Name {  get; set; }

        public string Position { get; set; }

        public string? Image { get;set; }

        public string? Instagram { get; set; }
    }
}
