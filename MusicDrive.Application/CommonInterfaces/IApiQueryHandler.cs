namespace MusicDrive.Application.CommonInterfaces;

public interface IApiQueryHandler<in TRequest> where TRequest : IApiQuery
{
    public Task<IApiResult> Handle(TRequest request, CancellationToken cancellationToken);
}