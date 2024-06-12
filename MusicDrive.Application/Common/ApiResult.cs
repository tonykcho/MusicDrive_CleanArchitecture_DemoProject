using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Application.Common;

public class ApiResult<TResponse> : IApiResult
{
    private readonly TResponse _payload;

    public ApiResult(TResponse payload)
    {
        _payload = payload;
    }

    public object? GetPayload()
    {
        return _payload;
    }
}

public sealed class InvalidRequestApiResult : IApiResult
{
}

public sealed class NoContentApiResult : IApiResult
{
}

public sealed class ResourceNotFoundApiResult : IApiResult
{
}

public sealed class ResourceAlreadyExistApiResult : IApiResult
{
}
