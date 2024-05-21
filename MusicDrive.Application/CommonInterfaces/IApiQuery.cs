namespace MusicDrive.Application.CommonInterfaces;

public interface IApiQuery
{
    public Task<IApiResult> Pipe<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IApiCommand;
}