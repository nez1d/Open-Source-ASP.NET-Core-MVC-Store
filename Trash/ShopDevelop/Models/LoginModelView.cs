using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Models
{
    public class LoginModelView
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Remember { get; set; }
    }
}
