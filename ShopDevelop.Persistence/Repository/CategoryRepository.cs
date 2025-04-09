using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Repository;
using ShopDevelop.Domain.Entities;

namespace ShopDevelop.Persistence.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext context;

    public CategoryRepository(ApplicationDbContext context) =>
        this.context = context;

    public async Task<int> CreateAsync(Category category, 
        CancellationToken cancellationToken)
    {
        var result = await this.GetByNameAsync(category.Name, cancellationToken);
        if (result is null)
        {
            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync();
        }
        return category.Id;
    }

    public async Task UpdateAsync(Category category, 
        CancellationToken cancellationToken)
    {
        Category model = await GetByIdAsync(category.Id, cancellationToken)
            ?? throw new NotFoundException(typeof(Category), category.Id);
            
        context.Categories.Update(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id, 
        CancellationToken cancellationToken)
    {
        Category category = await GetByIdAsync(id, cancellationToken);
        
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await context.Categories
            .ToListAsync(cancellationToken)
            ?? throw new NotFoundException(typeof(Category), null);
    }
    
    public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await context.Categories
            .FirstOrDefaultAsync(category => 
                category.Id == id, 
                cancellationToken)
            ?? throw new NotFoundException(typeof(Category), id);
    }

    public async Task<Category> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await context.Categories
            .FirstOrDefaultAsync(category => 
                category.Name == name, 
                cancellationToken) 
            ?? throw new NotFoundException(typeof(Category), name);
    }
}