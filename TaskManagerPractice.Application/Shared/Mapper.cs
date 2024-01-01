using TaskManagerPractice.Application.Tasks;
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
    
}