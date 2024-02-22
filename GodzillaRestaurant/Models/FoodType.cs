using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class FoodType
    {
        [Key]
        public int FoodTypeId { get; set; }
        [Required]
        public string FoodTypeName { get; set; }
        [Required]
        public int Sequence { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
