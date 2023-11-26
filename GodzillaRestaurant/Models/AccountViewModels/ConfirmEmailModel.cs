using Microsoft.AspNetCore.Mvc;

namespace GodzillaRestaurant.Models.AccountViewModels
{
    public class ConfirmEmailModel
    {
        [TempData]
        public string StatusMessage { get; set; }
    }
}
