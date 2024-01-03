using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Users.Errors;

public static class UserNameErrors
{
    public static Error NameIsEmpty
        => new(ErrorType.BusinessRuleViolation, "Username can not be empty");
    
    public static Error InvalidLength
        => new(ErrorType.BusinessRuleViolation, "Username must be between 3 and 50 characters");
    
    public static Error NameIsNotUnique(string name) 
        => new(ErrorType.BusinessRuleViolation, $"Username {name} is not unique");
}