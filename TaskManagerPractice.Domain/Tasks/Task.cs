using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.Events;
using TaskManagerPractice.Domain.Tasks.Exceptions;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Domain.Tasks;

public class Task: Entity<TaskId>
{
    public string Name { get; private set; }
    public UserId UserId { get; private set; }
    public string Description { get; private set; }
    public TaskState State { get; private set; }
    public TaskLifeRange LifeRange { get; private set; }
    
    // only for EF Core
    private Task() { }

    private Task(TaskId id, string name, UserId userId, string description, TaskState state, TaskLifeRange lifeRange)
    {
        Id = id;
        Name = name;
        UserId = userId;
        Description = description;
        State = state;
        LifeRange = lifeRange;
    }
    
    public static Task Create(TaskId id, string name, UserId userId, string description, DateTime createdAt)
    {
        var lifeRange = TaskLifeRange.Create(createdAt);
        var task = new Task(id, name, userId, description, TaskState.InProgress, lifeRange);
        task.Raise(new TaskCreatedDomainEvent(Guid.NewGuid(), DateTime.UtcNow, id));
        return task;
    }
    
    public void Complete(DateTime completedAt)
    {
        if (State != TaskState.InProgress)
            throw TaskStateException.TaskNotInProgress();
        LifeRange.Complete(DateTime.Now);
        State = TaskState.Completed;
        Raise(new TaskCompletedDomainEvent(Guid.NewGuid(), DateTime.UtcNow, Id));
    }
    
    public void Cancel()
    {
        if (State != TaskState.InProgress)
            throw TaskStateException.TaskNotInProgress();
        State = TaskState.Canceled;
        Raise(new TaskCanceledDomainEvent(Guid.NewGuid(), DateTime.UtcNow, Id));
    }

    public void Update(Task task)
    {
        if (State != TaskState.InProgress)
            throw TaskStateException.TaskNotInProgress();
        Name = task.Name;
        Description = task.Description;
        Raise(new TaskUpdatedDomainEvent(Guid.NewGuid(), DateTime.UtcNow, Id));
    }

}