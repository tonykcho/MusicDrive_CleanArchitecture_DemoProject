using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicDrive.Application.Common;
using MusicDrive.Application.Dtos;
using MusicDrive.Application.Queries.Albums;
using MusicDrive.DataAccess.Common;
using MusicDrive.Domain.Entities;
using NSubstitute;

namespace MusicDrive.Tests.UnitTest;

[TestClass]
public class GetAlbumHandlerUnitTest
{
    [TestMethod]
    public async Task GetAlbumById_ReturnOk_WhenAlbumExists()
    {
        var album = new Album()
        {
            Id = 1,
            AlbumName = "Unit Test",
            ReleaseDate = DateTime.UtcNow
        };
        var cancellationToken = new CancellationToken();
        
        var albumRepository = Substitute.For<IAlbumRepository>();
        albumRepository.GetByIdAsync(1, cancellationToken).Returns(album);
        
        var handler = new GetAlbumQueryHandler(albumRepository);

        var query = new GetAlbumQuery()
        {
            Id = 1
        };
        var result = await handler.Handle(query, cancellationToken);
        Assert.IsInstanceOfType<ApiResult<AlbumDto>>(result);

        var albumDto = (AlbumDto?)result.GetPayload();
        if (albumDto is null)
        {
            Assert.Fail("Album should not be null!");
        }
        Assert.AreEqual(album.AlbumName, albumDto.AlbumName);
    }
}