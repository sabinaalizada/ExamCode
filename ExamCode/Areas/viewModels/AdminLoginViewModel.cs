using System.ComponentModel.DataAnnotations;

namespace ExamCode.Areas.viewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength: 50, MinimumLength = 3)]

        public string Username { get; set; }
        [StringLength(maximumLength: 20, MinimumLength = 8)]

        public string Password { get; set; }
        
    }
}
