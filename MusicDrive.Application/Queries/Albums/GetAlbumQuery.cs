using MusicDrive.Application.Common;
using MusicDrive.Application.CommonInterfaces;
using MusicDrive.Application.Dtos;
using MusicDrive.Application.Mappers;
using MusicDrive.DataAccess.Common;
using MusicDrive.Domain.Entities;

namespace MusicDrive.Application.Queries.Albums;

public record GetAlbumQuery : IApiQuery
{
    public required int Id { get; set; }
}

public class GetAlbumQueryHandler(IAlbumRepository albumRepository) : IApiQueryHandler<GetAlbumQuery>
{
    public async Task<IApiResult> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var album = await albumRepository.GetByIdAsync(request.Id, cancellationToken);

        if (album == null)
        {
            return new ResourceNotFoundApiResult();
        }
        
        return new ApiResult<AlbumDto>(AlbumMapper.From(album));
    }
}