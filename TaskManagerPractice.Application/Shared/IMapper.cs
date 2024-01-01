using TaskManagerPractice.Application.Tasks;
using Task = TaskManagerPractice.Domain.Tasks.Task;

namespace TaskManagerPractice.Application.Shared;

public interface IMapper
{
    TaskDto MapTaskToTaskDto(Task task);
}