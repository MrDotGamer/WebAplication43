using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication43.Entities
{
    public class AppUser :IdentityUser
    {

        [Required]

        public string Section { get; set; }
    }
}
