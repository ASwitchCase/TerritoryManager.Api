using TerritoryManager.Api.Repositories;
using TerritoryManager.Api.Settings;
using TerritoryManager.Api.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDbSettings>();
builder.Services.AddSingleton<ITerritoryRepository,TerritoryRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapTerritoryRoutes();
app.Run();
