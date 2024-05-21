using Microsoft.AspNetCore.Mvc;
using MusicDrive.Application.Common;
using MusicDrive.Application.CommonInterfaces;

namespace MusicDrive.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    public IActionResult CreateResponse(IApiResult result)
    {
        if (result.GetType().IsGenericType && result.GetType().GetGenericTypeDefinition() == typeof(ApiResult<>))
        {
            return Ok(result.GetPayload());
        }

        return result switch
        {
            NoContentApiResult => NoContent(),
            ResourceNotFoundApiResult => NotFound(),
            ResourceAlreadyExistApiResult => BadRequest(),
            _ => StatusCode(StatusCodes.Status500InternalServerError)
        };
    }
}