using TerritoryManager.Api.Repositories;
using TerritoryManager.Api.Settings;
using TerritoryManager.Api.Routes;
using System.Diagnostics;
using TerritoryManager.Api.Middleware;
using EmailSender.api.Services;
using EmailSender.api.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<MongoDbSettings>();
builder.Services.AddTransient<IEmailSender, EmailSenderService>();
builder.Services.AddSingleton<ITerritoryRepository,TerritoryRepository>();
builder.Services.AddSingleton<IUserRepository,UserRepository>();
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

//Kill some errors 
app.UseMiddleware<ErrorKillerMiddleware>();
app.MapGet("/", () => "Hello World!");
app.MapPost("/email", async (IEmailSender sender, Email email) =>{
    await sender.SendEmailAsync(email.Recever,email.Subject,email.Message);
});
app.MapTerritoryRoutes();
app.MapUserRoutes();
app.Run();
