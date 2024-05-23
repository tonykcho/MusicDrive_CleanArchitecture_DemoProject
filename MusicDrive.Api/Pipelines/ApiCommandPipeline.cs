using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Api.Pipelines;

public class ApiCommandPipeline(IServiceProvider serviceProvider)
{
    public async Task<IApiResult> Pipe<TRequest>(
        TRequest request,
        CancellationToken cancellationToken = default) where TRequest : IApiCommand
    {
        // Insert any pre request execution behavior here

        // validation
        var handler = serviceProvider.GetRequiredService<IApiCommandHandler<TRequest>>();

        var result = await handler.Handle(request, cancellationToken);

        return result;
    }
}