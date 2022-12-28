using News365.Core.Entities;

namespace News365.DataAccess.Concrete;

public interface IEntityRepositoryAsync<T> where T : class, IEntity, new()
{
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
}
