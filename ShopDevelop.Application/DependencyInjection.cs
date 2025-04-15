﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ShopDevelop.Application.Data.Common.Mappings.Category;
using ShopDevelop.Application.Entities.Product.Queries.GetByArticle;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByPrice;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByRating;

namespace ShopDevelop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Product
        services.AddAutoMapper(typeof(CreateClothesProductMappingProfile));
        services.AddAutoMapper(typeof(CreateShoesProducMappingProfile));
        services.AddAutoMapper(typeof(UpdateProductMappingProfile));
        services.AddAutoMapper(typeof(GetProductMappingProfile));
        services.AddAutoMapper(typeof(GetProductByArticleMappingProfile));
        // Category
        services.AddAutoMapper(typeof(CreateCategoryMappingModel));
        services.AddAutoMapper(typeof(UpdateCategoryMappingProfile));
        services.AddAutoMapper(typeof(GetCategoryByIdMappingProfile));
        services.AddAutoMapper(typeof(GetCategoryByNameMappingProfile));
        // Seller
        services.AddAutoMapper(typeof(UpdateSellerMappingProfile));
        services.AddAutoMapper(typeof(CreateSellerMappingProfile));
        services.AddAutoMapper(typeof(GetAllSellersMappingProfile));
        services.AddAutoMapper(typeof(GetSellerByNameMappingProfile));
        // Review
        services.AddAutoMapper(typeof(CreateReviewMappingProfile));
        services.AddAutoMapper(typeof(UpdateReviewMappingProfile));
        // Order
        services.AddAutoMapper(typeof(CreateOrderMappingProfile));
        services.AddAutoMapper(typeof(UpdateOrderMappingProfile));
        services.AddAutoMapper(typeof(UpdateOrderMappingProfile));
        services.AddAutoMapper(typeof(GetOrderByIdMappingProfile));
        // Shopping Cart
        services.AddAutoMapper(typeof(AddToCartMappingProfile));
        
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        
        // Product
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateClothesProductCommand).Assembly,
                typeof(CreateShoesProductCommand).Assembly,
                typeof(UpdateProductCommand).Assembly,
                typeof(DeleteProductCommand).Assembly,
                typeof(GetProductByIdQuery).Assembly,
                typeof(GetMiniProductListQuery).Assembly,
                typeof(GetProductByArticleQuery).Assembly,
                typeof(GetSortedProductsByPriceQuery).Assembly,
                typeof(GetSortedProductsByRatingQuery).Assembly
                ));
        // Category
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateCategoryCommand).Assembly,
                typeof(UpdateCategoryCommand).Assembly,
                typeof(DeleteCategoryCommand).Assembly,
                typeof(GetCategoriesListQuery).Assembly,
                typeof(GetCategoryByIdQuery).Assembly,
                typeof(GetCategoryByNameQuery).Assembly
                ));
        // Seller
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateSellerCommand).Assembly,
                typeof(UpdateSellerCommand).Assembly,
                typeof(DeleteSellerCommand).Assembly,
                typeof(GetAllSellersListQuery).Assembly,
                typeof(GetSellerByIdQuery).Assembly,
                typeof(GetSellerByNameQuery).Assembly
                ));
        // Review
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateReviewCommand).Assembly,
                typeof(UpdateReviewCommand).Assembly,
                typeof(DeleteReviewCommand).Assembly,
                typeof(GetAllReviewsQuery).Assembly,
                typeof(GetAllReviewsByProductIdQuery).Assembly,
                typeof(GetAllReviewsByUserIdQuery).Assembly,
                typeof(GetFirstReviewsByDateQuery).Assembly,
                typeof(GetFirstReviewsByRatingQuery).Assembly
                ));
        // Order
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateOrderCommand).Assembly,
                typeof(UpdateOrderCommand).Assembly,
                typeof(DeleteOrderCommand).Assembly,
                typeof(GetAllOrdersQuery).Assembly,
                typeof(GetOrderByIdQuery).Assembly,
                typeof(GetOrdersByProductIdQuery).Assembly,
                typeof(GetOrdersByUserIdQuery).Assembly
                ));
        // Shopping Cart
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(AddToCartCommand).Assembly,
                typeof(RemoveFromCartCommand).Assembly,
                typeof(ClearCartCommand).Assembly,
                typeof(GetShoppingCartItemsByUserIdQuery).Assembly,
                typeof(GetAllCartItemsQuery).Assembly,
                typeof(GetTotalShoppingCartPriceQuery).Assembly
                ));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));
        
        return services;
    }
}