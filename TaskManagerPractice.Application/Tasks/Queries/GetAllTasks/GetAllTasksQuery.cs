using MediatR;

namespace TaskManagerPractice.Application.Tasks.Queries.GetAllTasks;

public record GetAllTasksQuery: IRequest<List<TaskDto>>;