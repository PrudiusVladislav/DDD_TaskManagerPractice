using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using TaskManagerPractice.Domain.Tasks;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;
using CustomTask = TaskManagerPractice.Domain.Tasks.Task;
using SysThreadingTask = System.Threading.Tasks.Task;

namespace TaskManagerPractice.Persistence.Tasks;

public class TasksRepository: ITasksRepository
{
    private readonly TaskManagerDbContext _dbContext;
    
    public TasksRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyCollection<CustomTask>> GetAllAsync(CancellationToken cancellationToken)
    {
        return (await _dbContext.Tasks
                .AsNoTracking()
                .ToListAsync(cancellationToken))
            .AsReadOnly();
    }

    public async Task<CustomTask?> GetByIdAsync(TaskId id, CancellationToken cancellationToken)
    {
        return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<CustomTask>> GetByUserIdAsync(UserId userId, CancellationToken cancellationToken)
    {
        return (await _dbContext.Tasks
                .Where(t => t.UserId == userId)
                .AsNoTracking()
                .ToListAsync(cancellationToken))
            .AsReadOnly();
    }

    public async SysThreadingTask AddAsync(CustomTask task, CancellationToken cancellationToken)
    {
        await _dbContext.Tasks.AddAsync(task, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async SysThreadingTask UpdateAsync(CustomTask task, CancellationToken cancellationToken)
    {
        var taskToUpdate = await _dbContext.Tasks.FindAsync([task.Id], cancellationToken: cancellationToken);
        if (taskToUpdate is null) 
            throw new InvalidOperationException($"Task with id {task.Id} not found");
        taskToUpdate.Update(task);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async SysThreadingTask DeleteAsync(TaskId taskId, CancellationToken cancellationToken)
    {
        var taskToDelete = await _dbContext.Tasks.FindAsync([taskId], cancellationToken: cancellationToken);
        if (taskToDelete is null) 
            return;
        
        _dbContext.Tasks.Remove(taskToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}