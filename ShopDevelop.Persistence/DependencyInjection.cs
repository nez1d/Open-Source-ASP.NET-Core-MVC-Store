using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Product.Command.Create;
using ShopDevelop.Persistence.Entities.Product.Command.Update;
using ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Persistence.Entities.Product.Queries.GetProduct;

namespace ShopDevelop.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateProductCommandHandler).Assembly,
                typeof(UpdateProductCommandHandler).Assembly,
                typeof(GetProductQueryHandler).Assembly,
                typeof(GetMiniProductListHandler).Assembly));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Port=5438;DataBase=ShopDevelop; User Id=postgres;Password=postgres ;Include Error Detail=True");
        });
        
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        
        return services;
    }
}