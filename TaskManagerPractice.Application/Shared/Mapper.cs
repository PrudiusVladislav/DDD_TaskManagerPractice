using TaskManagerPractice.Application.Tasks;
using TaskManagerPractice.Application.Users;
using TaskManagerPractice.Domain.Users;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Application.Shared;

public class Mapper: IMapper
{
    public TaskDto MapTaskToTaskDto(Task task)
    {
        return new TaskDto(task.Id.Value,
            task.Name,
            task.UserId.Value,
            task.Description,
            task.State.ToString(),
            task.LifeRange.CreatedAt,
            task.LifeRange.CompletedAt);
    }
    
    public UserDto MapUserToUserDto(User user)
    {
        return new UserDto(user.Id.Value, user.Name.Value, user.Email.Value);
    }
}