using FluentValidation;
using MusicDrive.Application.Common;
using MusicDrive.Application.CommonInterfaces;

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

public class CreateAlbumCommandHandler(IValidator<CreateAlbumCommand> validator)
    : IApiCommandHandler<CreateAlbumCommand>
{
    public async Task<IApiResult> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);

        if (result.IsValid == false)
        {
            return new InvalidRequestApiResult();
        }
        
        throw new NotImplementedException();
    }
}