using FluentValidation;
using MusicDrive.Application.Common;
using MusicDrive.Application.CommonInterfaces;
using MusicDrive.DataAccess.Common;
using MusicDrive.Domain.Entities;

namespace MusicDrive.Application.Commands.Albums;

public record CreateAlbumCommand : IApiCommand
{
    public required string AlbumName { get; set; }
    
    public class Validator : AbstractValidator<CreateAlbumCommand>
    {
        public Validator()
        {
            RuleFor(command => command.AlbumName).NotEmpty();
        }
    }
}

public class CreateAlbumCommandHandler(IAlbumRepository albumRepository, IValidator<CreateAlbumCommand> validator)
    : IApiCommandHandler<CreateAlbumCommand>
{
    public async Task<IApiResult> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.IsValid == false)
        {
            return new InvalidRequestApiResult();
        }

        var album = new Album()
        {
           AlbumName = request.AlbumName,
           ReleaseDate = DateTime.UtcNow
        };

        await albumRepository.AddAsync(album, cancellationToken);

        var success = await albumRepository.SaveChangesAsync(cancellationToken);

        if (success)
        {
            return new NoContentApiResult();
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}