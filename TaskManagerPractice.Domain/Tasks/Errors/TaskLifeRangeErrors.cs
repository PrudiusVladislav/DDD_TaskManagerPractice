using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Tasks.Errors;

public static class TaskLifeRangeErrors
{
    public static Error CreatedAtGreaterThanCompletedAt()
        => new Error(ErrorType.BusinessRuleViolation, "CreatedAt cannot be greater than CompletedAt");
}