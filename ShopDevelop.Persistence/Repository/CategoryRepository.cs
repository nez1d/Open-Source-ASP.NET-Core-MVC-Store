﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<Guid> Create(Category category)
    {
        var result = await this.GetByName(category.Name);
        if (result == null)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Guid.Empty; /*category.Id; */
        }
        
        return Guid.Empty;
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

    public Task<object> GetById(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetById(Guid id)
    {
        return null; /*await context.Categories
            .FirstOrDefaultAsync(category => category.Id == id);*/
    }

    public async Task<Category> GetByName(string name)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(category => category.Name == name);
        
        if (category != null)
            return category;

        return null;
    }
}