using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Application.Tasks.CreateTask;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.API.Extensions;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this WebApplication app)
    {
        app.MapGet("/tasks", async (ITasksRepository repository, IMapper mapper,
            CancellationToken cancellationToken) =>
        {
            var tasks = await repository.GetAllAsync(cancellationToken);
            return Results.Ok(tasks.Select(mapper.MapTaskToTaskDto));
        });
        
        app.MapGet("/tasks/{id}", async (Guid id, ITasksRepository repository, IMapper mapper,
             CancellationToken cancellationToken) =>
        {
            var task = await repository.GetByIdAsync(new TaskId(id), cancellationToken);
            return task is null ? Results.NotFound() : Results.Ok(mapper.MapTaskToTaskDto(task));
        });
        
        app.MapPost("/tasks", async (CreateTaskCommand command,
            IMediator mediator, IMapper mapper, CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            
            if (!result.IsSuccess)
                return Results.BadRequest(result.Error);
            
            return Results.Created($"/tasks/{result.Value!.Id}", mapper.MapTaskToTaskDto(result.Value));
        });
    }
}