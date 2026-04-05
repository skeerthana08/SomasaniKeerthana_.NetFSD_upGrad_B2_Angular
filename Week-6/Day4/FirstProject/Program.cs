var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to my FIRST ASP.NET CORE APP");

app.Run();
