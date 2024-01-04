using TaskManagerPractice.Application.Tasks;
using TaskManagerPractice.Application.Users;
using TaskManagerPractice.Domain.Users;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Application.Abstractions;

public interface IMapper
{
    TaskDto MapTaskToTaskDto(Task task);
    UserDto MapUserToUserDto(User user);
}