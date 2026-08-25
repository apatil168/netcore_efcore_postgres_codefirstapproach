using Customer.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Customer.Data.Repositories
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Repository(DbContext context) : base(context) { }


        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return;
            Context.Remove(entity);
        }

        public void Save(TEntity entity)
        {
            if (entity.Id == 0)
                Context.Set<TEntity>().Add(entity);
            else
                Context.Entry(entity).State = EntityState.Modified;
        }

        IQueryable<TEntity> Set()
            => Context.Set<TEntity>();
    }
}
