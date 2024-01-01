using MediatR;
using TaskManagerPractice.Application.Tasks.CreateTask;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.API.Extensions;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        app.MapGet("/tasks", async (ITasksRepository repository,
            CancellationToken cancellationToken) =>
        {
            var tasks = await repository.GetAllAsync(cancellationToken);
            return Results.Ok(tasks);
        });
        
        app.MapGet("/tasks/{id}", async (ITasksRepository repository,
            Guid id, CancellationToken cancellationToken) =>
        {
            var task = await repository.GetByIdAsync(new TaskId(id), cancellationToken);
            return task is null ? Results.NotFound() : Results.Ok(task);
        });
        
        app.MapPost("/tasks", async (CreateTaskCommand command,
            IMediator mediator, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.IsSuccess ? Results.Created($"/tasks/{result.Value!.Value}", result) 
                : Results.BadRequest(result.Error);
        });
    }
}