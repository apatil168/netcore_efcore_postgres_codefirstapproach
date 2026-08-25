using System.Linq.Expressions;

namespace Customer.Data.Repositories
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity?> GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
    }
}
