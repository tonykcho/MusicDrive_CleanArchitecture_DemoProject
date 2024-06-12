using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MusicDrive.DataAccess.Common;
using MusicDrive.DataAccess.DbContexts;
using MusicDrive.Domain.Common;

namespace MusicDrive.DataAccess.Repositories;

public abstract class BaseRepository<T>(MusicDriveDbContext dbContext) : IBaseRepository<T>
    where T : BaseEntity, IAggregateRoot
{
    
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await dbContext.Set<T>().SingleOrDefaultAsync(data => data.Id == id, cancellationToken);
    }

    public async Task<T?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await dbContext.Set<T>().SingleOrDefaultAsync(data => data.Guid == guid, cancellationToken);
    }

    public async Task<IEnumerable<T>> ListAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        await dbContext.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        dbContext.Update(entity);
    }

    public void Remove(T entity)
    {
        dbContext.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        return await dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
}