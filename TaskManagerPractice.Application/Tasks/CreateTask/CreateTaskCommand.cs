using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
using Task = TaskManagerPractice.Domain.Tasks.Task;
namespace TaskManagerPractice.Application.Tasks.CreateTask;

public record CreateTaskCommand(string Name, UserId UserId, string Description, DateTime CreatedAt)
    : IRequest<Result<TaskId>>;