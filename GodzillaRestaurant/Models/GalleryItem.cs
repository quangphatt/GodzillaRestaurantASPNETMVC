using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class GalleryItem
    {
        [Key]
        public int GalleryItemId { get; set; }

        public string Image { get; set; }
    }
}
