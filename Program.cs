using TerritoryManager.Api.Repositories;
using TerritoryManager.Api.Settings;
using TerritoryManager.Api.Routes;
using System.Diagnostics;
using TerritoryManager.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDbSettings>();
builder.Services.AddSingleton<ITerritoryRepository,TerritoryRepository>();
builder.Services.AddSingleton<IUserRepository,UserRepository>();
var app = builder.Build();

//Kill some errors 
app.UseMiddleware<ErrorKillerMiddleware>();
app.MapGet("/", () => "Hello World!");
app.MapTerritoryRoutes();
app.MapUserRoutes();
app.Run();
