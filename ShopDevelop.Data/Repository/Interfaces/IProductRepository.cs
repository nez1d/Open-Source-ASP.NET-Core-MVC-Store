namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IProductRepository<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> Add(TEntity entity);
        public void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}