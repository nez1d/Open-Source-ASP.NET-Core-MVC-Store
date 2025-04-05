using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Persistence.Entities.Category.Command.Create;
using ShopDevelop.Persistence.Entities.Category.Command.Delete;
using ShopDevelop.Persistence.Entities.Category.Command.Update;
using ShopDevelop.Persistence.Entities.Category.Queries.GetAllCategories;
using ShopDevelop.Persistence.Entities.Category.Queries.GetCategoryById;
using ShopDevelop.Persistence.Entities.Category.Queries.GetCategoryByName;
using ShopDevelop.Persistence.Entities.Orders.Commands.Create;
using ShopDevelop.Persistence.Entities.Orders.Commands.Delete;
using ShopDevelop.Persistence.Entities.Orders.Commands.Update;
using ShopDevelop.Persistence.Entities.Orders.Queries.GetById;
using ShopDevelop.Persistence.Entities.Orders.Queries.GetByProductId;
using ShopDevelop.Persistence.Entities.Orders.Queries.GetByUserId;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Clothes;
using ShopDevelop.Persistence.Entities.Product.Command.Create.Shoes;
using ShopDevelop.Persistence.Entities.Product.Command.Update;
using ShopDevelop.Persistence.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Persistence.Entities.Product.Queries.GetProduct;
using ShopDevelop.Persistence.Entities.Review.Commands.Create;
using ShopDevelop.Persistence.Entities.Review.Commands.Delete;
using ShopDevelop.Persistence.Entities.Review.Commands.Update;
using ShopDevelop.Persistence.Entities.Review.Queries.GetAllByProductId;
using ShopDevelop.Persistence.Entities.Review.Queries.GetAllReviewsByUserId;
using ShopDevelop.Persistence.Entities.Review.Queries.GetFirstByCreatedDate;
using ShopDevelop.Persistence.Entities.Review.Queries.GetFirstByRating;
using ShopDevelop.Persistence.Entities.Seller.Command.Create;
using ShopDevelop.Persistence.Entities.Seller.Command.Delete;
using ShopDevelop.Persistence.Entities.Seller.Command.Update;
using ShopDevelop.Persistence.Entities.Seller.Queries.GetAll;
using ShopDevelop.Persistence.Entities.Seller.Queries.GetByName;
using ShopDevelop.Persistence.Entities.ShoppingCart.Command.Add;
using ShopDevelop.Persistence.Entities.ShoppingCart.Query.GetByUserId;

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
                typeof(UpdateReviewCommandHandler).Assembly,
                typeof(DeleteReviewCommandHandler).Assembly,
                typeof(GetAllCategoriesQueryHandler).Assembly,
                typeof(GetAllReviewsByProductIdQueryHandler).Assembly,
                typeof(GetAllReviewsByUserIdQueryHandler).Assembly));
        // Order
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateOrderCommandHandler).Assembly,
                typeof(UpdateOrderCommandHandler).Assembly,
                typeof(DeleteOrderCommandHandler).Assembly,
                typeof(GetAllCategoriesQueryHandler).Assembly,
                typeof(GetOrderByIdQueryHandler).Assembly,
                typeof(GetOrdersByProductIdQueryHandler).Assembly,
                typeof(GetOrdersByUserIdQueryHandler).Assembly,
                typeof(GetFirstReviewsByRatingQueryHandler).Assembly,
                typeof(GetFirstReviewsByCreatedDateQueryHandler).Assembly));
        // Shopping Cart
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(AddToCartCommandHandler).Assembly,
                typeof(GetShoppingCartItemsByUserIdQueryHandler).Assembly
                
                /*,
                typeof(ClearCartCommandHandler).Assembly,
                typeof(RemoveFromCartCommandHandler).Assembly*/
                ));
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql("Server=localhost;Port=5438;DataBase=ShopDevelop; User Id=postgres;Password=postgres ;Include Error Detail=True");
        });
        
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetService<ApplicationDbContext>());
        
        return services;
    }
}