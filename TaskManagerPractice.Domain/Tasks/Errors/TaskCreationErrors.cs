using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Tasks.Errors;

public static class TaskCreationErrors
{
    public static Error UserNotFound => new(ErrorType.NotFound, "User not found");
    
    public static Error TaskWithThisNameAlreadyExists 
        => new(ErrorType.Conflict, "Task with this name is already assigned to the user");
}