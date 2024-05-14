using MusicDrive.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpLogging();

app.Run();