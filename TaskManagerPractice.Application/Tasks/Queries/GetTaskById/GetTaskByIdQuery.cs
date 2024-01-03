using MediatR;

namespace TaskManagerPractice.Application.Tasks.Queries.GetTaskById;

public record GetTaskByIdQuery(Guid Id): IRequest<TaskDto?>;