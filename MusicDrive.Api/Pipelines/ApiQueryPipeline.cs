using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Api.Pipelines;

public class ApiQueryPipeline(IServiceProvider serviceProvider)
{
    public async Task<IApiResult> Pipe<TRequest>(TRequest request,
        CancellationToken cancellationToken = default) where TRequest : IApiQuery
    {
        // Insert any pre request execution behavior here

        var handler = serviceProvider.GetRequiredService<IApiQueryHandler<TRequest>>();

        var result = await handler.Handle(request, cancellationToken);

        return result;
    }
}