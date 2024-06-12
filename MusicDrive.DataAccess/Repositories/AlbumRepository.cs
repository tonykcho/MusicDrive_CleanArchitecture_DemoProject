using MusicDrive.DataAccess.Common;
using MusicDrive.DataAccess.DbContexts;
using MusicDrive.Domain.Entities;

namespace MusicDrive.DataAccess.Repositories;

public class AlbumRepository(MusicDriveDbContext dbContext) : BaseRepository<Album>(dbContext), IAlbumRepository
{
}