namespace Customer.Data.Repositories
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
    {
        
        void Save(TEntity entity);
        Task Delete(int id);
        
    }
}
