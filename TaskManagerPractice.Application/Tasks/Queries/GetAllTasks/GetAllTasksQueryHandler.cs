using System.Collections.Immutable;
using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Tasks;

namespace TaskManagerPractice.Application.Tasks.Queries.GetAllTasks;

public class GetAllTasksQueryHandler: IRequestHandler<GetAllTasksQuery, List<TaskDto>>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IMapper _mapper;
    
    public GetAllTasksQueryHandler(ITasksRepository tasksRepository, IMapper mapper)
    {
        _tasksRepository = tasksRepository;
        _mapper = mapper;
    }
    
    public async Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _tasksRepository.GetAllAsync(cancellationToken);
        return tasks.Select(_mapper.MapTaskToTaskDto).ToList();
    }
}