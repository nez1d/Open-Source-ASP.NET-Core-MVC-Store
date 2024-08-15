using System.ComponentModel.DataAnnotations;

namespace ShopDevelop.Data.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string? Phone { get; set; }
        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public string? ImagePath { get; set; }

        public List<ShoppingCart> Cart { get; set; }

        public List<ShoppingCartItem> CartItems { get; set; }
    }
}
