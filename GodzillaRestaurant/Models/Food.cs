using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set;}
        public string FoodType { get; set;}
        public int Price { get; set; }
    }
}
