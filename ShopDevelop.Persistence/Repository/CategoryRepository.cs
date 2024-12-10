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

    public async Task<Guid> Create(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return category.Id;
    }

    public async Task Update(Category category)
    {
        var model = GetById(category.Id);
        if (model != null)
        {
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var category = await GetById(id);     
        if (category == null)
        {
            throw new ArgumentException();
        }
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await context.Categories
            .Where(category => category.Id != null)
            .ToListAsync();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await context.Categories
            .FirstOrDefaultAsync(category => category.Id == id);
    }
}