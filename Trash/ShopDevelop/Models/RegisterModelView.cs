using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Models
{
    public class RegisterModelView
    {
        [Required(ErrorMessage = "The login field is required")]
        public string Login { get; set; }
        [Required(ErrorMessage = "The password field is required")]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "The email field is required")]
        public string Email { get; set; }
    }
}
