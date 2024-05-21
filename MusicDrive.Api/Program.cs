using MusicDrive.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.ConfigureLogging();

builder.RegisterPipelines();

builder.RegisterApiHandlers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.UseHttpLogging();

app.Run();