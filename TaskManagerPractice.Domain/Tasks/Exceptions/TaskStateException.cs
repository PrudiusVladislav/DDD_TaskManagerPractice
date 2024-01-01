namespace TaskManagerPractice.Domain.Tasks.Exceptions;

public class TaskStateException: Exception
{
    private TaskStateException(string message)
        : base(message)
    {
    }
    
    public static TaskStateException TaskNotInProgress()
    {
        return new TaskStateException("Invalid operation. Task is not in progress");
    }
}