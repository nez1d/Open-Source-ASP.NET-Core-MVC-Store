namespace RenStore.Domain.Interfaces.Repository;

public interface IRepositoryBase<T>
{
    Task<Guid> Create(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(Guid? id);
}