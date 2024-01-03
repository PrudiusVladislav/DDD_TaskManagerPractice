using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Tasks.Errors;
using TaskManagerPractice.Domain.Tasks.Errors;

namespace TaskManagerPractice.Domain.Tasks.ValueObjects;

public class TaskLifeRange
{
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    
    private TaskLifeRange(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }
    
    public static TaskLifeRange Create(DateTime createdAt)
    {
        return new TaskLifeRange(createdAt);
    }
    
    public Result Complete(DateTime completedAt)
    {
        if (CreatedAt > completedAt)
            return Result.Fail(TaskLifeRangeErrors.CreatedAtGreaterThanCompletedAt());
        
        CompletedAt = completedAt;
        return Result.Ok();
    }
}