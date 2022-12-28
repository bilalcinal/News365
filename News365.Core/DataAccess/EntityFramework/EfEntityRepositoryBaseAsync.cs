using Microsoft.EntityFrameworkCore;
using News365.Core.Entities;

namespace News365.DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBaseAsync<TEntity, TContext> : IEntityRepositoryAsync<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
