using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DateTime { get; set; }
        public int NPeople {  get; set; }
        public string Message { get; set; }
        public int BookingStatus { get; set; }
    }
}
