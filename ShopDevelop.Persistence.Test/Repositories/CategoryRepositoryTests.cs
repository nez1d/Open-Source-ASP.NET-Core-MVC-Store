using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Domain.Entities;
using ShopDevelop.Persistence.Repository;
using ShopDevelop.Persistence.Test.Common;

namespace ShopDevelop.Persistence.Test.Repositories;

public class CategoryRepositoryTests : TestCommandBase
{
    private CategoryRepository categoryRepository;

    [Fact]
    public async Task CreateCategoryAsync_Success_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        var categoryId = await categoryRepository.CreateAsync(new Category
        {
            Id = 324232,
            Name = "Created Category Name",
            Description = "Created Category Description",
            ImagePath = "/images/main/img.png",
        }, 
        CancellationToken.None);
        // Assert
        Assert.NotNull(await categoryRepository.GetByIdAsync(categoryId, CancellationToken.None));
    }

    [Fact]
    public async Task UpdateCategoryAsync_Success_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        string updatedName = "Updated Category Name";
        string updatedDescription = "Updated Category Name";
        // Act
        var category = await categoryRepository.GetByIdAsync(
            ProductContextFactory.CategoryIdForUpdate,
            CancellationToken.None);

        category.Name = updatedName;
        category.Description = updatedDescription;
        
        await categoryRepository.UpdateAsync(category, CancellationToken.None);
        // Assert
        var result = await categoryRepository.GetByIdAsync(
            category.Id, 
            CancellationToken.None
        );
        
        Assert.Equal(result.Name, result.Name);
        Assert.Equal(result.Description, result.Description);
    }

    [Fact]
    public async Task UpdateCategoryAsync_FainOnWrong_TestId()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await categoryRepository.UpdateAsync(new Category()
                { Id = 5483834 }, 
                CancellationToken.None
            ));
    }

    [Fact]
    public async Task DeleteCategoryAsync_Success_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        await categoryRepository.DeleteAsync(ProductContextFactory.CategoryIdForDelete, CancellationToken.None);
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await categoryRepository.GetByIdAsync(
                ProductContextFactory.CategoryIdForDelete,
                CancellationToken.None)
        );
    }

    [Fact]
    public async Task DeleteCategoryAsync_FailOnWrongId_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await categoryRepository.DeleteAsync(
                358376347, 
                CancellationToken.None
            )
        );
    }

    [Fact]
    public async Task GetAllCategoryAsync_Success_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        var products = await categoryRepository.GetAllAsync(CancellationToken.None);
        // Assert
        Assert.Equal(3, products.Count());
    }

    [Fact]
    public async Task GetCategoryByIdAsync_Success_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        var category = await categoryRepository.GetByIdAsync(
            ProductContextFactory.CategoryIdForUpdate, 
            CancellationToken.None
        );
        // Assert
        Assert.NotNull(category);
        Assert.Equal(ProductContextFactory.CategoryIdForUpdate, category.Id);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_FailOnWrongId_Test()
    {
        // Arrange
        categoryRepository = new CategoryRepository(context);
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await categoryRepository.GetByIdAsync(
                7445675, 
                CancellationToken.None
            )
        );
    }
}