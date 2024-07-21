using ShopDevelop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Web.Models
{
    public class UserModelView
    {
        [Required]
        public User User {  get; set; }
    }
}
