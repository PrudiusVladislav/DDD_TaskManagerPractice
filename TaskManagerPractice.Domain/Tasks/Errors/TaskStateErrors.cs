using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Tasks.Errors;

public static class TaskStateErrors
{
    public static Error TaskNotInProgress
        => new Error(ErrorType.BusinessRuleViolation, "Invalid operation. Task is not in progress");
}