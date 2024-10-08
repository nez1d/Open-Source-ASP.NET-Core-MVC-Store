namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IProductRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> Add(TEntity entity);
        public void Remove(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}