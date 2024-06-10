using MusicDrive.Domain.Common;

namespace MusicDrive.Domain.Entities;

public class Album : BaseEntity, IAggregateRoot
{
    public required string AlbumName { get; set; }
    public DateTime ReleaseDate { get; set; }
}