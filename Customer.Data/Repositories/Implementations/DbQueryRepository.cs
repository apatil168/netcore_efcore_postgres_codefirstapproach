using Customer.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data.Repositories
{
    public class DbQueryRepository<TEntity> : Repository<TEntity>, IDbQueryRepository<TEntity>
        where TEntity : BaseEntity
    {
        public DbQueryRepository(DbContext context) : base(context) { }

        public IQueryable<TEntity> ExecuteFunction(string pgFunctionName)
        {
            return Context.Set<TEntity>().FromSqlRaw<TEntity>(pgFunctionName);
        }

    }
}
