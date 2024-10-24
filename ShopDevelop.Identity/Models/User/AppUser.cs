using Microsoft.AspNetCore.Identity;

namespace ShopDevelop.Identity.Models.User
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
    }
}