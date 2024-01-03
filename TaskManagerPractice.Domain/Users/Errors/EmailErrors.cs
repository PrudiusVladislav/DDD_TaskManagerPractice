using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Users.Errors;

public static class EmailErrors
{
    public static Error EmailIsEmpty =>
        new Error(ErrorType.BusinessRuleViolation,"Email cannot be empty");
    
    public static Error InvalidFormat 
        => new Error(ErrorType.BusinessRuleViolation, "Invalid email format");
    
    public static Error EmailIsNotUnique(string email)
        => new Error(ErrorType.BusinessRuleViolation, $"Email {email} is not unique");
}