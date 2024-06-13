using Microsoft.AspNetCore.Mvc.Testing;

namespace MusicDrive.Tests.IntegrationTest;

public class MusicDriveApiTest
{
    private MockApp App { get; set; }
    protected HttpClient Client { get; set; }

    protected MusicDriveApiTest()
    {
        App = new MockApp();
        Client = App.CreateClient();
    }

    private class MockApp : WebApplicationFactory<Program>
    {
        public MockApp()
        {
        }
    }
}
