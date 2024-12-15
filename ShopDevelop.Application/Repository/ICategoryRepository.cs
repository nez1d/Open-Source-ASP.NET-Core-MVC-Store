namespace ShopDevelop.Application.Repository;

public interface ICategoryRepository
{
    /// <summary>
    /// Create new a Category.
    /// </summary>
    /// <param name="category">Category entity.</param>
    /// <returns>Return a category Id.</returns>
    Task<Guid> Create(Domain.Models.Category category);
    /// <summary>
    /// Update a category.
    /// </summary>
    /// <param name="category">Category entity.</param>
    /// <returns></returns>
    Task Update(Domain.Models.Category category);
    /// <summary>
    /// Delete a category.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns></returns>
    Task Delete(Guid id);
    /// <summary>
    /// Get a category by Id.
    /// </summary>
    /// <param name="id">Category Id.</param>
    /// <returns>Return a category entity.</returns>
    Task<Domain.Models.Category> GetById(Guid id);
    /// <summary>
    /// Vet category by cagetory name.
    /// </summary>
    /// <param name="name">Category name</param>
    /// <returns></returns>
    Task<Domain.Models.Category> GetByName(string name);
    /// <summary>
    /// Get all categories.
    /// </summary>
    /// <returns>Return List Cagetory entities.</returns>
    Task<IEnumerable<Domain.Models.Category>> GetAll();
}
