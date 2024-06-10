using MusicDrive.Application.Dtos;
using MusicDrive.Domain.Entities;

namespace MusicDrive.Application.Mappers;

public static class AlbumMapper
{
    public static AlbumDto From(Album album)
    {
        return new AlbumDto()
        {
            AlbumName = album.AlbumName,
            ReleaseDate = album.ReleaseDate
        };
    }
}