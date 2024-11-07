namespace ShopDevelop.Application.Services.Identity;

public interface IIdentityService
{
    Task<Guid> CreateUserAsync(string userName, string password);

    Task DeleteUserAsync(Guid userId);

    Task<bool> AuthorizeAsync(Guid userId, string policyName);

    Task<bool> IsInRoleAsync(Guid userId, string role);

    Task<string?> GetUserNameAsync(Guid userId);
}
