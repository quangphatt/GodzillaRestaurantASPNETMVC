using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId {  get; set; }
        public string PaymentName { get; set; }
        public string Image {  get; set; }
    }
}
