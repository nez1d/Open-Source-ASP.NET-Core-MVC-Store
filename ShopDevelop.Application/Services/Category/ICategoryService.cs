namespace ShopDevelop.Application.Services.Category;

public interface ICategoryService
{
    /// <summary>
    /// Create new Category.
    /// </summary>
    /// <param name="category">Category entity.</param>
    /// <returns>Return Category Id.</returns>
    Task<Guid> CreateCategoryAsync(string name, string description);
    /// <summary>
    /// Edit a Category.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns></returns>
    Task EditCategoryAsync(Domain.Models.Category category);
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
    Task<Domain.Models.Category> GetCategoryByIdAsync(Guid id);
    /// <summary>
    /// Get all Categories.
    /// </summary>
    /// <returns>Return List a Categories.</returns>
    Task<IEnumerable<Domain.Models.Category>> GetAllCategory();
}