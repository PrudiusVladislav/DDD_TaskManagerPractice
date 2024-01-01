using TaskManagerPractice.API.Extensions;
using TaskManagerPractice.API.Middleware;
using TaskManagerPractice.Application;
using TaskManagerPractice.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPersistence(builder.Configuration);
    builder.Services.AddApplication();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapTaskEndpoints();
    app.MapUserEndpoints();
}

app.Run();

