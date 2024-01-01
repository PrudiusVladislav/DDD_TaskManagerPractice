using TaskManagerPractice.Domain.Tasks.Exceptions;

namespace TaskManagerPractice.Domain.Tasks.ValueObjects;

public class TaskLifeRange
{
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    
    private TaskLifeRange(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }
    
    public static TaskLifeRange? Create(DateTime createdAt)
    {
        return new TaskLifeRange(createdAt);
    }
    
    public void Complete(DateTime completedAt)
    {
        if (CreatedAt > completedAt)
            throw InvalidTaskLifeRangeException.CreatedAtGreaterThanCompletedAt();
        
        CompletedAt = completedAt;
    }
}