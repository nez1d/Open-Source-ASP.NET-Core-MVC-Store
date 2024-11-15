namespace ShopDevelop.Domain.Contracts.Users;

public class LoginUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}