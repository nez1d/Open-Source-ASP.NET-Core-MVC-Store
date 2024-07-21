using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Models
{
    public class RegisterModelView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
