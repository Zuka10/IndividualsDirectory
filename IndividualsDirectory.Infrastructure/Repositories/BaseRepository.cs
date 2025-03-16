using IndividualsDirectory.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IndividualsDirectory.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    private readonly IndividualsDbContext _context;
    private readonly DbSet<TEntity> _set;

    public BaseRepository(IndividualsDbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _set.AsNoTracking()
            .Where(expression)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _set.Where(expression)
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _set.AsNoTracking()
            .FirstOrDefaultAsync(expression, cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _set.FirstOrDefaultAsync(expression, cancellationToken);
    }

    public ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _set.AddAsync(entity, cancellationToken);
        return ValueTask.CompletedTask;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _set.AddRangeAsync(entities, cancellationToken);
    }

    public ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _set.Update(entity);
        return ValueTask.CompletedTask;
    }

    public void Remove(TEntity entity)
    {
        _set.Remove(entity);
    }
}