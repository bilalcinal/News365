using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using News365.Core.Entities;

namespace News365.DataAccess.Concrete.EntityFramework;

public class EfEntityRepositoryBaseAsync<TEntity, TContext> : IEntityRepositoryAsync<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
{
    public async Task AddAsync(TEntity entity)
	{
		using var context = new TContext();
		await context.Set<TEntity>().AddAsync(entity);
		await context.SaveChangesAsync();
	}

	public async Task<TEntity> GetAsync(int id)
	{
		using var context = new TContext();
		return await context.Set<TEntity>().FindAsync(id);
	}

	public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
	{
		using var context = new TContext();
		IQueryable<TEntity> query = context.Set<TEntity>().AsQueryable();
		if (filter != null)
		{
			query = query.Where(filter);
		}
		if (include != null)
		{
			query = include(query);
		}
		return await query.AsNoTracking().SingleOrDefaultAsync();
	}

    public Task<TEntity> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
	{
		using var context = new TContext();
		IQueryable<TEntity> query = context.Set<TEntity>();
		if (filter != null)
		{
			query = query.Where(filter);
		}
		if (includes != null)
		{
			foreach (Expression<Func<TEntity, object>> include in includes)
			{
				query = query.Include(include);
			}
		}
		return await query.FirstOrDefaultAsync();
	}

	public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
	{
		using var context = new TContext();
		IQueryable<TEntity> query = context.Set<TEntity>();
		if (filter != null)
		{
			query = query.Where(filter);
		}
		if (includes != null)
		{
			foreach (Expression<Func<TEntity, object>> include in includes)
			{
				query = query.Include(include);
			}
		}
		if (orderBy != null)
		{
			return await orderBy(query).ToListAsync();
		}
		return await query.ToListAsync();
	}

	public async Task RemoveAsync(TEntity entity)
	{
		using var context = new TContext();
		context.Set<TEntity>().Remove(entity);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(TEntity entity)
	{
		using var context = new TContext();
		context.Entry(entity).State = EntityState.Modified;
		await context.SaveChangesAsync();
	}

    
}
