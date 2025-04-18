global using RenStore.Application.Interfaces;
global using RenStore.Persistence.Entities.Category.Command.Create;
global using RenStore.Persistence.Entities.Category.Command.Delete;
global using RenStore.Persistence.Entities.Category.Command.Update;
global using RenStore.Persistence.Entities.Category.Queries.GetAllCategories;
global using RenStore.Persistence.Entities.Category.Queries.GetCategoryById;
global using RenStore.Persistence.Entities.Category.Queries.GetCategoryByName;
global using RenStore.Persistence.Entities.Orders.Commands.Create;
global using RenStore.Persistence.Entities.Orders.Commands.Delete;
global using RenStore.Persistence.Entities.Orders.Commands.Update;
global using RenStore.Persistence.Entities.Orders.Queries.GetById;
global using RenStore.Persistence.Entities.Orders.Queries.GetByProductId;
global using RenStore.Persistence.Entities.Orders.Queries.GetByUserId;
global using RenStore.Persistence.Entities.Product.Command.Create.Clothes;
global using RenStore.Persistence.Entities.Product.Command.Create.Shoes;
global using RenStore.Persistence.Entities.Product.Command.Update;
global using RenStore.Persistence.Entities.Product.Queries.GetAllMinimizedProducts;
global using RenStore.Persistence.Entities.Product.Queries.GetProduct;
global using RenStore.Persistence.Entities.Review.Commands.Create;
global using RenStore.Persistence.Entities.Review.Commands.Delete;
global using RenStore.Persistence.Entities.Review.Commands.Update;
global using RenStore.Persistence.Entities.Review.Queries.GetAllByProductId;
global using RenStore.Persistence.Entities.Review.Queries.GetAllReviewsByUserId;
global using RenStore.Persistence.Entities.Review.Queries.GetFirstByCreatedDate;
global using RenStore.Persistence.Entities.Review.Queries.GetFirstByRating;
global using RenStore.Persistence.Entities.Seller.Command.Create;
global using RenStore.Persistence.Entities.Seller.Command.Delete;
global using RenStore.Persistence.Entities.Seller.Command.Update;
global using RenStore.Persistence.Entities.Seller.Queries.GetAll;
global using RenStore.Persistence.Entities.Seller.Queries.GetByName;
global using RenStore.Persistence.Entities.ShoppingCart.Command.Add;
global using RenStore.Persistence.Entities.ShoppingCart.Command.Clear;
global using RenStore.Persistence.Entities.ShoppingCart.Command.Remove;
global using RenStore.Persistence.Entities.ShoppingCart.Query.GetAll;
global using RenStore.Persistence.Entities.ShoppingCart.Query.GetByUserId;
global using RenStore.Persistence.Entities.ShoppingCart.Query.GetTotalPrice;
global using RenStore.Persistence.Entities.Product.Queries.GetByNovelty;
global using RenStore.Persistence.Entities.Product.Queries.GetBySellerId;
global using RenStore.Persistence.Entities.Product.Queries.GetMyArticle;
global using RenStore.Persistence.Entities.Product.Queries.GetSortedByPrice;
global using RenStore.Persistence.Entities.Product.Queries.GetSortedByRating;