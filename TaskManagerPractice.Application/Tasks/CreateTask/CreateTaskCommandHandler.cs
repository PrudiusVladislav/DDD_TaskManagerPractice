using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
using CustomTask = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Application.Tasks.CreateTask;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<TaskId>>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IUsersRepository _usersRepository;
    
    public CreateTaskCommandHandler(ITasksRepository tasksRepository, IUsersRepository usersRepository)
    {
        _tasksRepository = tasksRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<TaskId>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user is null) 
            return Result<TaskId>.Fail("User not found");
        
        var task = CustomTask.Create(
            TypedIdBase.New<TaskId>(),
            request.Name, 
            request.UserId,
            request.Description,
            request.CreatedAt);
        await _tasksRepository.AddAsync(task, cancellationToken);
        return Result<TaskId>.Ok(task.Id);
    }
}