using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Category.Command.Create;
using ShopDevelop.Persistence.Entities.Category.Command.Delete;
using ShopDevelop.Persistence.Entities.Category.Command.Update;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Clothes;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Shoes;
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
        // Product
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateClothesProductCommandHandler).Assembly,
                typeof(CreateShoesProductCommandHandler).Assembly,
                typeof(UpdateProductCommandHandler).Assembly,
                typeof(GetProductQueryHandler).Assembly,
                typeof(GetMiniProductListHandler).Assembly));
        // Category
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateCategoryCommandHandler).Assembly,
                typeof(UpdateCategoryCommandHandler).Assembly,
                typeof(DeleteCategoryCommandHandler).Assembly));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Port=5438;DataBase=ShopDevelop; User Id=postgres;Password=postgres ;Include Error Detail=True");
        });
        
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        
        return services;
    }
}