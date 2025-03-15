using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Interfaces;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext context;
    private ICategoryRepository categoryRepositoryImplementation;

    public CategoryRepository(IApplicationDbContext context) =>
        this.context = context;

    public async Task<int> CreateAsync(Category category, 
        CancellationToken cancellationToken)
    {
        var result = await this.GetByNameAsync(category.Name);
        if (result == null)
        {
            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync();
            return category.Id;
        }
        return 0;
    }

    public async Task UpdateAsync(Category category, 
        CancellationToken cancellationToken)
    {
        var model = GetByIdAsync(category.Id);
        if (model != null)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id, 
        CancellationToken cancellationToken)
    {
        var category = await GetByIdAsync(id);     
        if (category == null)
        {
            throw new ArgumentException();
        }
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories
            .Where(category => category.Id != null)
            .ToListAsync();
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await context.Categories
            .FirstOrDefaultAsync(category => category.Id == id)
            ?? throw new NotFoundException(typeof(Category), id);
    }

    public async Task<Category> GetByNameAsync(string name)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(category => category.Name == name);
        
        if (category != null)
            return category;

        return null;
    }
}