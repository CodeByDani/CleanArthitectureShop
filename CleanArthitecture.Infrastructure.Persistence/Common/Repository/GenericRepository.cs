using CleanArthitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArthitecture.Infrastructure.Persistence.Common.Repository;

public class GenericRepository<TEntity>(DBContextConnection dbContext) where TEntity : class, IEntityMarker
{
    protected DBContextConnection _dbContext = dbContext;
    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);

    }

    public async Task<TEntity> FindByIdAsync(long id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();

    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}