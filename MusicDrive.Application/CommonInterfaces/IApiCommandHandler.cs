namespace MusicDrive.Application.CommonInterfaces;

public interface IApiCommandHandler<in TRequest> where TRequest : IApiCommand
{
    public Task<IApiResult> Handle(TRequest request, CancellationToken cancellationToken);
}