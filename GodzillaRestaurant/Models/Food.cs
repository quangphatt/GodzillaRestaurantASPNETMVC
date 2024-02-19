using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodzillaRestaurant.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        [ForeignKey("FoodType")]
        public int FoodTypeId { get; set; }

        public virtual FoodType FoodType { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }
    }
}
