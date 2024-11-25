using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Application.Entities.User.Queries.GetProfile;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Entities.User.Queries.GetProfile;

public class GetUserProfileHandler
    : IRequestHandler<GetUserProfileQuery, UserProfileLookupDto>
{
    private readonly IApplicationDbContext applicationDbContext;
    private readonly UserManager<ApplicationUser> userManager;
    public GetUserProfileHandler(IApplicationDbContext applicationDbContext,
        UserManager<ApplicationUser> userManager) =>
    (this.applicationDbContext, this.userManager) = (applicationDbContext, userManager);

    public async Task<UserProfileLookupDto> Handle(
        GetUserProfileQuery request,
        CancellationToken cancellationToken)
    {
        var AppUser = await userManager.FindByIdAsync(request.Id.ToString());

        if (AppUser != null)
        {
            var result = new UserProfileLookupDto(
                request.Id, AppUser.FirstName,
                AppUser.Email, AppUser.PhoneNumber,
                AppUser.Country, AppUser.City,
                (double)AppUser.Balance, AppUser.ImagePath);

            return result;
        }
        return null;
    }
}