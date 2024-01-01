using MediatR;
using TaskManagerPractice.Application.Users.CreateUser;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.API.Extensions;

public static class UsersEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (IUsersRepository repository,
            CancellationToken cancellationToken) =>
        {
            var users = await repository.GetAllAsync(cancellationToken);
            return Results.Ok(users);
        });
        
        app.MapGet("/users/{id}", async (Guid id, IUsersRepository repository,
             CancellationToken cancellationToken) =>
        {
            var user = await repository.GetByIdAsync(new UserId(id), cancellationToken);
            return user is null ? Results.NotFound() : Results.Ok(user);
        });
        
        app.MapPost("/users", async (CreateUserCommand command,
            IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Results.Created($"/users/{result.Value!.Id}", result.Value) 
                : Results.BadRequest(result.Error);
        });
    }
}