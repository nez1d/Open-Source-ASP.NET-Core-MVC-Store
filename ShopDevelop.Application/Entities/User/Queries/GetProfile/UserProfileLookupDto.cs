namespace ShopDevelop.Application.Entities.User.Queries.GetProfile;

public class UserProfileLookupDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public double Balance { get; set; }
    public string ImagePath { get; set; }


}