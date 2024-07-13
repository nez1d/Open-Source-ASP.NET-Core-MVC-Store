using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        /*[Required]
        public string ReturnUrl { get; set; }*/
    }
}
