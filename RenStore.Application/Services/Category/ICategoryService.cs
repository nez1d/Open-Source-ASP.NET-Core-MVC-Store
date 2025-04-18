namespace RenStore.Application.Services.Category;

public interface ICategoryService
{
    /// <summary>
    /// Create new Category.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="category">Category entity.</param>
    /// <returns>Return Category Id.</returns>
    Task<int> CreateCategoryAsync(string name, string description);
    /// <summary>
    /// Edit a Category.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns></returns>
    Task EditCategoryAsync(RenStore.Domain.Entities.Category category);
    /// <summary>
    /// Delete a Category.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns></returns>
    Task DeleteCategoryAsync(Guid id);
    /// <summary>
    /// Get Category by Id.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns>Return a Category entity.</returns>
    Task<RenStore.Domain.Entities.Category> GetCategoryByIdAsync(Guid id);
    /// <summary>
    /// Vet category by category name.
    /// </summary>
    /// <param name="name">Category name</param>
    /// <returns></returns>
    Task<RenStore.Domain.Entities.Category> GetByName(string name);
    /// <summary>
    /// Get all Categories.
    /// </summary>
    /// <returns>Return List a Categories.</returns>
    Task<IEnumerable<RenStore.Domain.Entities.Category>> GetAllCategory();
}