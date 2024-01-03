using MediatR;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Tasks.Commands.CreateTask;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<TaskId>>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly TasksDomainService _tasksDomainService;
    
    public CreateTaskCommandHandler(ITasksRepository tasksRepository, TasksDomainService tasksDomainService)
    {
        _tasksRepository = tasksRepository; 
        _tasksDomainService = tasksDomainService;
    }
    
    public async Task<Result<TaskId>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var taskCreationResult = await _tasksDomainService.CreateTaskAsync(
            userId,
            request.Name,
            request.Description,
            cancellationToken);
        
        if (taskCreationResult.IsFailure)
            return Result.Merge<TaskId>(taskCreationResult);
        
        await _tasksRepository.AddAsync(taskCreationResult.Value!, cancellationToken);
        return Result.Ok(taskCreationResult.Value!.Id);
    }
}