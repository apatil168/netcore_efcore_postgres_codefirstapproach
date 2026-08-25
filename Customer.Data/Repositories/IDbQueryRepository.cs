namespace Customer.Data.Repositories
{
    public interface IDbQueryRepository<TEntity> : IRepository<TEntity>
    {
        IQueryable<TEntity> ExecuteFunction(string pgFunctionName);
    }
}
