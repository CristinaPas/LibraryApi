using Microsoft.EntityFrameworkCore;

namespace LibraryShopApi.Repositories.RepositoryBaseClass;

public class RepositoryBase<T> where T : class
{
    protected readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }


    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }
    public async Task AddRangeAsync(ICollection<T> collection, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(collection, cancellationToken);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(ICollection<T> collection)
    {
        _dbSet.RemoveRange(collection);
    }

}