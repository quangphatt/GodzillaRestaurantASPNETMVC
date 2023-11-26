using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodzillaRestaurant.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "character varying(256)")]
        public string FullName { get; set; }
    }
}
