using System.Linq.Expressions;

namespace IndividualsDirectory.Domain.Abstractions;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    ValueTask AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    ValueTask UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Remove(TEntity entity);
}