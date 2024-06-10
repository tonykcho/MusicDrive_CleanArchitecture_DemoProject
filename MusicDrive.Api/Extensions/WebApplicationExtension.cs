using Microsoft.EntityFrameworkCore;
using MusicDrive.DataAccess.DbContexts;

namespace MusicDrive.Api.Extensions;

public static class WebApplicationExtension
{
    public static async Task MigrateAsync(this WebApplication app, CancellationToken cancellationToken = default)
    {
        await using (var scope = app.Services.CreateAsyncScope())
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<WebApplication>>();

            var context = scope.ServiceProvider.GetRequiredService<MusicDriveDbContext>();

            try
            {
                logger.LogInformation("--> Start migrating MusicDrive.");

                await context.Database.MigrateAsync(cancellationToken);
                
                logger.LogInformation("--> Migrate MusicDrive Success.");
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message, "--> An Error occured while migrating the database used on context.");
                throw;
            }
        }
    }
}
