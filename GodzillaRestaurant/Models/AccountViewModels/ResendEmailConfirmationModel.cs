using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GodzillaRestaurant.Models.AccountViewModels
{
    public class ResendEmailConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
