﻿using MusicDrive.Application.Common;
using MusicDrive.Application.CommonInterfaces;
using MusicDrive.Domain.Entities;

namespace MusicDrive.Application.Queries.Albums;

public record GetAlbumQuery : IApiQuery
{
    public required int Id { get; set; }
}

public class GetAlbumQueryHandler : IApiQueryHandler<GetAlbumQuery>
{
    public async Task<IApiResult> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        Album album = new Album()
        {
            AlbumName = "Hello",
            ReleaseDate = new DateTime()
        };
        
        return new ApiResult<Album>(album);
    }
}