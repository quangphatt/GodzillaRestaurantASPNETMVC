using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
