using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicDrive.Application.Commands.Albums;

namespace MusicDrive.Tests.IntegrationTest;

[TestClass]
public class BasicTest : MusicDriveApiTest
{
    public BasicTest() : base()
    {
    }

    [TestMethod]
    public async Task Test()
    {
        CancellationToken cancellationToken = new CancellationToken();
        var command = new CreateAlbumCommand()
        {
            AlbumName = "Test3"
        };
        var request = JsonSerializer.Serialize(command);
        var content = new StringContent(request, Encoding.UTF8, "application/json");
        
        var createResult = await Client.PostAsync("/api/Albums", content, cancellationToken);
        Assert.AreEqual(HttpStatusCode.NoContent, createResult.StatusCode);
        
        var result = await Client.GetAsync("/api/Albums/3", cancellationToken);
        Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
    }
}