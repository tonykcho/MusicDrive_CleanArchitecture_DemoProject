using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Core;

namespace MusicDrive.Api.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.RequestPath | HttpLoggingFields.RequestMethod
                | HttpLoggingFields.ResponseStatusCode | HttpLoggingFields.ResponseBody;
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
        });
    }
}