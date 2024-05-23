using Microsoft.AspNetCore.Mvc;
using MusicDrive.Api.Pipelines;
using MusicDrive.Application.Commands.Albums;
using MusicDrive.Application.Queries.Albums;

namespace MusicDrive.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(ApiCommandPipeline commandPipeline, ApiQueryPipeline apiQueryPipeline) : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetAlbumById([FromRoute] GetAlbumQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return CreateResponse(await apiQueryPipeline.Pipe(query, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumCommand command,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return CreateResponse(await commandPipeline.Pipe(command, cancellationToken));
    }
}