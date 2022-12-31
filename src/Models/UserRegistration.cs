using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class UserRegistration
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password confirmation does not match")]
        public string ConfirmPassword { get; set; }

        public string? Name { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
