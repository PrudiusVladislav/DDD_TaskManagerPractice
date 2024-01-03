using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;

namespace TaskManagerPractice.Application.Tasks.Queries.GetTaskById;

public class GetTaskByIdQueryHandler: IRequestHandler<GetTaskByIdQuery, TaskDto?>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IMapper _mapper;
    
    public GetTaskByIdQueryHandler(ITasksRepository tasksRepository, IMapper mapper)
    {
        _tasksRepository = tasksRepository;
        _mapper = mapper;
    }
    
    public async Task<TaskDto?> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var id = new TaskId(request.Id);
        var task = await _tasksRepository.GetByIdAsync(id, cancellationToken);
        return task is null ? null : _mapper.MapTaskToTaskDto(task);
    }
}