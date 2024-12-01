using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Persistence.Entities.User.Queries.GetProfile;

namespace ShopDevelop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(GetMiniProductListHandler).Assembly,
                typeof(GetUserProfileHandler).Assembly));

        var connectionString = configuration["DefaultConnection"];
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        return services;
    }
}