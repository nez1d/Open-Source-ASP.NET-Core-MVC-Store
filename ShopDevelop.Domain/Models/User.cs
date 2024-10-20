namespace ShopDevelop.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } 
        public string Country { get; set; } 
        public string City { get; set; } 
        public double Balance { get; set; } 
        public bool IsActive { get; set; } 
        public DateTime CreatedDate { get; set; }
        public string ImagePath { get; set; } 
        public string ImageFooterPath { get; set; } 
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<ShoppingCartItem> CartItems { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Guid OrderId { get; set; }
    }
}
