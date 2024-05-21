using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Application.Commands.Albums;

public class CreateAlbumCommand : IApiCommand
{
    public required string AlbumName { get; set; }
}

public class CreateAlbumCommandHandler : IApiCommandHandler<CreateAlbumCommand>
{
    public Task<IApiResult> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}