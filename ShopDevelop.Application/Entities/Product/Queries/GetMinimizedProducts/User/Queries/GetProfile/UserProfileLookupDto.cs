namespace ShopDevelop.Application.Entities.User.Queries.GetProfile;

public class UserProfileLookupDto
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public double Balance { get; set; }
    public string ImagePath { get; set; }
    public string ImageFooterPath { get; set; }

    public UserProfileLookupDto(Guid id, string login, string firstName, string lastName,
        string patornymic, string email, string phone, string country, string city, 
        double balance, string imagePath, string imageFooterPath)
    {
        Id = id;
        Login = login;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patornymic;
        Email = email;
        Phone = phone;
        Country = country;
        City = city;
        Balance = balance;
        ImagePath = imagePath;
        ImageFooterPath = imageFooterPath;
    }
}