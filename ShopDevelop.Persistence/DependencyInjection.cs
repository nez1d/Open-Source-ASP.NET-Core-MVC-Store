using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Category.Command.Create;
using ShopDevelop.Persistence.Entities.Category.Command.Delete;
using ShopDevelop.Persistence.Entities.Category.Command.Update;
using ShopDevelop.Persistence.Entities.Category.Queries.GetAllCategories;
using ShopDevelop.Persistence.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Persistence.Entities.Category.Queries.GetCategoryByName;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Clothes;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Shoes;
using ShopDevelop.Persistence.Entities.Product.Command.Update;
using ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Persistence.Entities.Product.Queries.GetProduct;
using ShopDevelop.Persistence.Entities.Review.Commands.Create;
using ShopDevelop.Persistence.Entities.Review.Commands.Delete;
using ShopDevelop.Persistence.Entities.Review.Queries.GetAllByProductId;
using ShopDevelop.Persistence.Entities.Review.Queries.GetAllReviewsByUserId;
using ShopDevelop.Persistence.Entities.Seller.Command.Create;
using ShopDevelop.Persistence.Entities.Seller.Command.Delete;
using ShopDevelop.Persistence.Entities.Seller.Command.Update;
using ShopDevelop.Persistence.Entities.Seller.Queries.GetAll;
using ShopDevelop.Persistence.Entities.Seller.Queries.GetByName;

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
                typeof(GetMiniProductListQueryHandler).Assembly));
        // Category
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateCategoryCommandHandler).Assembly,
                typeof(UpdateCategoryCommandHandler).Assembly,
                typeof(DeleteCategoryCommandHandler).Assembly,
                typeof(GetAllCategoriesQueryHandler).Assembly,
                typeof(GetCategoryByIdQueryHandler).Assembly,
                typeof(GetCategoryByNameQueryHandler).Assembly));
        // Seller
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateSellerCommandHandler).Assembly,
                typeof(UpdateSellerCommandHandler).Assembly,
                typeof(DeleteSellerCommandHandler).Assembly,
                typeof(GetAllSellersQueryHandler).Assembly,
                typeof(GetCategoryByIdQueryHandler).Assembly,
                typeof(GetSellerByNameQueryHandler).Assembly));
        // Review
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateReviewCommandHandler).Assembly,
                typeof(DeleteReviewCommandHandler).Assembly,
                typeof(GetAllCategoriesQueryHandler).Assembly,
                typeof(GetAllReviewsByProductIdQueryHandler).Assembly,
                typeof(GetAllReviewsByUserIdQueryHandler).Assembly));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Port=5438;DataBase=ShopDevelop; User Id=postgres;Password=postgres ;Include Error Detail=True");
        });
        
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        
        return services;
    }
}