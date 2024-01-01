using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
using CustomTask = TaskManagerPractice.Domain.Tasks.Task;
using SysThreadingTask = System.Threading.Tasks.Task;

namespace TaskManagerPractice.Domain.Tasks;

public interface ITasksRepository
{
    Task<IReadOnlyCollection<CustomTask>> GetAllAsync(CancellationToken cancellationToken);
    Task<CustomTask?> GetByIdAsync(TaskId id, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<CustomTask>> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken);
    SysThreadingTask AddAsync(CustomTask task, CancellationToken cancellationToken);
    SysThreadingTask UpdateAsync(CustomTask task, CancellationToken cancellationToken);
    SysThreadingTask DeleteAsync(TaskId taskId, CancellationToken cancellationToken);
}