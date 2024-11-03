using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Interfaces;
using ShopDevelop.Domain.Models;

namespace ShopDevelop.Persistence.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext context;
    public CategoryRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<Guid> CreateCategory(Category category,
        CancellationToken cancellationToken)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }

    public Task DeleteCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task EditCategory(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Category>> GetAllCategory()
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        return await context.Categories
            .FirstOrDefaultAsync(product => product.Id == id);
    }
}