using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPractice.Application.Abstractions;
using TaskManagerPractice.Application.Users.Commands.CreateUser;
using TaskManagerPractice.Application.Users.Login;
using TaskManagerPractice.Application.Users.Queries.GetAllUsers;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.API.Extensions;

public static class UsersEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return Results.Ok(result);
        });
        
        app.MapGet("/users/{id}", async (Guid id, IUsersRepository repository,
            IMapper mapper, CancellationToken cancellationToken) =>
        {
            var user = await repository.GetByIdAsync(new UserId(id), cancellationToken);
            return user is null ? Results.NotFound() : Results.Ok(mapper.MapUserToUserDto(user));
        }).RequireAuthorization();
        
        app.MapPost("/users", async (CreateUserCommand command,
            IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);

            return result.Match<IResult>(
                onFailure: errors => ResultsMapper.MapFailureResult(errors),
                onSuccess: () => Results.Created($"/users/{result.Value!.Value}",
                    result.Value.Value));
        });
        
        app.MapPost("/users/login", async ([FromBody]LoginRequest loginRequest, 
            [FromServices]IMediator mediator, CancellationToken cancellationToken) =>
        {
            var command = new LoginCommand(loginRequest.Email);
            var result = await mediator.Send(command, cancellationToken);

            return result.Match<IResult>(
                onFailure: errors => ResultsMapper.MapFailureResult(errors),
                onSuccess: token => Results.Ok(token));
        });
    }
}