using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Image {  get; set; }
        public string Introduction { get; set; }
        public string Description { get; set; }
        public string Outro { get; set; }
    }
}
