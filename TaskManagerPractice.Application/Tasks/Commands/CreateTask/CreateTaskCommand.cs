using MediatR;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
namespace TaskManagerPractice.Application.Tasks.Commands.CreateTask;

public record CreateTaskCommand(string Name, Guid UserId, string Description)
    : IRequest<Result<TaskId>>;