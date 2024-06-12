using Microsoft.EntityFrameworkCore.Storage;
using MusicDrive.Domain.Common;

namespace MusicDrive.DataAccess.Common;

public interface IBaseRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<T?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken);

    Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);
    
    Task AddAsync(T entity, CancellationToken cancellationToken);
    
    void Update(T entity);

    void Remove(T entity);

    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}
