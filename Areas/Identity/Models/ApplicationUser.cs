using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApp1.Areas.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        [Required]
        public DateTime UntilDate {get; set;}
    }
}