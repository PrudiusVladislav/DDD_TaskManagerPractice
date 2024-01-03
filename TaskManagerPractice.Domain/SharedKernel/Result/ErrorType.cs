namespace TaskManagerPractice.Domain.SharedKernel.Result;

public enum ErrorType
{
    Conflict,
    NotFound,
    BusinessRuleViolation,
    Unauthorized
}