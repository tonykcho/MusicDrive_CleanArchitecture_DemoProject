using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Api.Pipelines;

public class AlbumCommandPipeline(IServiceProvider serviceProvider) : ApiCommandPipeline(serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public override async Task<IApiResult> Pipe<TRequest>(TRequest request,
        CancellationToken cancellationToken = default)
    {
        // Insert any pre request execution album behavior here

        // validation

        var handler = _serviceProvider.GetRequiredService<IApiCommandHandler<TRequest>>();

        var result = await handler.Handle(request, cancellationToken);

        return result;
    }
}