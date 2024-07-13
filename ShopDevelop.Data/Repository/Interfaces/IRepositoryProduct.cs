namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IRepositoryProduct<TEntity> where TEntity : class
    {
        public Task<List<TEntity>> Add(TEntity entity);
        public void Remove(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}