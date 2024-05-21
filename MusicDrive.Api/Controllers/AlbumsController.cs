using Microsoft.AspNetCore.Mvc;
using MusicDrive.Api.Pipelines;
using MusicDrive.Application.Commands.Albums;

namespace MusicDrive.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController(AlbumCommandPipeline commandPipeline) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumCommand command,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return CreateResponse(await commandPipeline.Pipe(command, cancellationToken));
    }
}