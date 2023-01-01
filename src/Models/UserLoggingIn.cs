using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class UserLoggingIn
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
