using System.ComponentModel.DataAnnotations;

namespace ClinicApplication.Models.ViewModels
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage ="Not a valid Mail ID")]
        public string Username { get; set; }= string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(4, ErrorMessage = "Password must be at least 4 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
