using System.Reflection;
using FluentValidation;
using MusicDrive.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();
builder.ConfigurePostgreSql();

builder.RegisterPipelines();
builder.RegisterApiHandlers();
builder.RegisterApiRepositories();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("MusicDrive.Application"));

var app = builder.Build();

await app.MigrateAsync();

app.MapControllers();

app.UseHttpLogging();

app.Run();

public partial class Program { }
