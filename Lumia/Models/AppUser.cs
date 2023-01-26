using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lumia.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Fullname { get; set; }
    }
}
