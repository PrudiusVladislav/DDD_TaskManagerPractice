using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Tasks.Errors;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Domain.Tasks;

public class TasksDomainService
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IUsersRepository _usersRepository;
    
    public TasksDomainService(ITasksRepository tasksRepository, IUsersRepository usersRepository)
    {
        _tasksRepository = tasksRepository;
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<Task>> CreateTaskAsync(UserId userId, string name, string description, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null) 
            return Result.Fail<Task>(TaskCreationErrors.UserNotFound);
        
        var tasksByUser = await _tasksRepository.GetByUserIdAsync(userId, cancellationToken);
        if (tasksByUser.Any(task => task.Name == name))
            return Result.Fail<Task>(TaskCreationErrors.TaskWithThisNameAlreadyExists);
        
        var task = Task.Create(
            TypedIdBase.New<TaskId>(),
            name, 
            userId,
            description,
            DateTime.Now);
        return Result.Ok(task);
    }
}