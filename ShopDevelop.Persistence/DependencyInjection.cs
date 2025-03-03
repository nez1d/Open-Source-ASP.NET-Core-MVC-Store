using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Data.Common.Mappings;
using ShopDevelop.Application.Entities.Product.Queries.GetAllProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Product.Command.Create;
using ShopDevelop.Persistence.Entities.Product.Command.Update;
using ShopDevelop.Persistence.Entities.Product.Queries.GetProductDetails;

namespace ShopDevelop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateClothesProductCommandHandler).Assembly,
                typeof(UpdateProductCommandHandler).Assembly,
                typeof(GetProductDetailsQueryHandler).Assembly));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Port=5438;DataBase=ShopDevelop; User Id=postgres;Password=postgres ;Include Error Detail=True");
        });
        
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        
        return services;
    }
}