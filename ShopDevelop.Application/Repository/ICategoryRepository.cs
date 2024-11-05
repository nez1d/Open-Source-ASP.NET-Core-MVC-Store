namespace ShopDevelop.Application.Repository;

public interface ICategoryRepository
{
    Task<Guid> Create(Domain.Models.Category category);
    Task Update(Domain.Models.Category category);
    Task Delete(Guid id);
    Task<Domain.Models.Category> GetById(Guid id);
    Task<IEnumerable<Domain.Models.Category>> GetAll();
}
