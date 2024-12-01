using ShopDevelop.Application.Entities.User.Queries.GetProfile;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Application.Services.User;

public interface IUserService
{
    /// <summary>
    /// Register User by email and password.
    /// </summary>
    /// <param name="email">User email.</param>
    /// <param name="password">User password.</param>
    /// <returns>Return register Task.</returns>
    Task Register(string email, string password);
    /// <summary>
    /// Login User by email and password.
    /// </summary>
    /// <param name="email">User email.</param>
    /// <param name="password">User password.</param>
    /// <returns>Return new Auth JwtToken.</returns>
    Task<string> Login(string email, string password);
    /// <summary>
    /// Find User by UserId.
    /// </summary>
    /// <param name="id">User Id.</param>
    /// <returns>Return User Entity.</returns>
    Task<ApplicationUser> FindById(Guid id);
    /// <summary>
    /// Getting User Profile Model by UserId.
    /// </summary>
    /// <param name="id">User Id.</param>
    /// <returns>Return UserProfileDto Entity.</returns>
    Task<UserProfileLookupDto> GetUserProfile(Guid id);
    /// <summary>
    /// Recover User Password by email and password.
    /// </summary>
    /// <param name="email">User Email.</param>
    /// <param name="password">User Password.</param>
    /// <returns></returns>
    Task RecoverPassword(string email, string password);
    /// <summary>
    /// Recover User Email by old email and password.
    /// </summary>
    /// <param name="email">User email.</param>
    /// <param name="password">User password.</param>
    /// <returns></returns>
    Task RecoverEmail(string email, string password);
}