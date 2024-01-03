using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Application.Tasks.Commands.CreateTask;
using TaskManagerPractice.Application.Tasks.Queries.GetAllTasks;
using TaskManagerPractice.Application.Tasks.Queries.GetTaskById;


namespace TaskManagerPractice.API.Extensions;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        app.MapGet("/tasks", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var tasks = await mediator.Send(new GetAllTasksQuery(), cancellationToken);
            return Results.Ok(tasks);
        });
        
        app.MapGet("/tasks/{id}", async (Guid id, IMediator mediator,
             CancellationToken cancellationToken) =>
        {
            var task = await mediator.Send(new GetTaskByIdQuery(id), cancellationToken);
            return task is null ? Results.NotFound() : Results.Ok(task);
        });
        
        app.MapPost("/tasks", async (CreateTaskCommand command,
            IMediator mediator, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            return result.Match<IResult>(
                onFailure: (errors) => Results.BadRequest(errors),
                onSuccess: () => Results.Created($"/tasks/{result.Value!.Value}", result.Value.Value));
        });
    }
}