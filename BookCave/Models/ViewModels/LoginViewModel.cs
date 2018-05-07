using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}