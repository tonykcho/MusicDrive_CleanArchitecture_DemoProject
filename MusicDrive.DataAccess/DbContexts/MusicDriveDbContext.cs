using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicDrive.Domain.Common;

namespace MusicDrive.DataAccess.DbContexts;

public class MusicDriveDbContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(configuration.GetConnectionString("MusicDrive"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        cancellationToken.ThrowIfCancellationRequested();

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                {
                    entry.Entity.Guid = Guid.NewGuid();
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                }
                case EntityState.Modified:
                {
                    entry.Entity.LastUpdatedAt = DateTime.UtcNow;
                    break;
                }
            }
        }
        
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}