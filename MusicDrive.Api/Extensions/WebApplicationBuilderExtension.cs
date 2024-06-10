using System.Reflection;
using Microsoft.AspNetCore.HttpLogging;
using MusicDrive.Application.Commands.Albums;
using MusicDrive.Application.CommonInterfaces;
using MusicDrive.DataAccess.DbContexts;
using Serilog;

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
                                                                  | HttpLoggingFields.ResponseStatusCode |
                                                                  HttpLoggingFields.ResponseBody;
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
        });
    }

    public static void ConfigurePostgreSql(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<MusicDriveDbContext>();
    }

    public static void RegisterPipelines(this WebApplicationBuilder builder)
    {
        foreach (var type in typeof(Program).Assembly.GetTypes().Where(x =>
                     x.Name.EndsWith("Pipeline") && x.IsAbstract == false && x.IsInterface == false))
        {
            builder.Services.AddTransient(type);
        }
    }

    public static void RegisterApiHandlers(this WebApplicationBuilder builder)
    {
        foreach (var type in Assembly.Load("MusicDrive.Application").GetTypes().Where(x =>
                     x.Name.EndsWith("QueryHandler") && x.IsAbstract == false && x.IsInterface == false))
        {
            foreach (var iface in type.GetInterfaces().Where(x =>
                         x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IApiQueryHandler<>)))
            {
                builder.Services.AddTransient(iface, type);
            }
        }
        
        foreach (var type in Assembly.Load("MusicDrive.Application").GetTypes().Where(x =>
                     x.Name.EndsWith("CommandHandler") && x.IsAbstract == false && x.IsInterface == false))
        {
            foreach (var iface in type.GetInterfaces().Where(x =>
                         x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IApiCommandHandler<>)))
            {
                builder.Services.AddTransient(iface, type);
            }
        }
    }
}