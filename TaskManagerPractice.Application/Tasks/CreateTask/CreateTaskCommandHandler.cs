using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
using CustomTask = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Application.Tasks.CreateTask;

public class CreateTaskCommandHandler: IRequestHandler<CreateTaskCommand, Result<CustomTask>>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IUsersRepository _usersRepository;
    
    public CreateTaskCommandHandler(ITasksRepository tasksRepository, IUsersRepository usersRepository)
    {
        _tasksRepository = tasksRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<CustomTask>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var userId = new UserId(request.UserId);
        var user = await _usersRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null) 
            return Result<CustomTask>.Fail("User not found");
        
        var userTasks = await _tasksRepository.GetByUserIdAsync(userId, cancellationToken);
        if (userTasks.Any(task => task.Name == request.Name))
            return Result<CustomTask>.Fail("Task with this name is already assigned to this user");
        
        var task = CustomTask.Create(
            TypedIdBase.New<TaskId>(),
            request.Name, 
            userId,
            request.Description,
            DateTime.Now);
        await _tasksRepository.AddAsync(task, cancellationToken);
        return Result<CustomTask>.Ok(task);
    }
}