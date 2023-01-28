using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExamCode.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FullName { get; set; }
    }
}
