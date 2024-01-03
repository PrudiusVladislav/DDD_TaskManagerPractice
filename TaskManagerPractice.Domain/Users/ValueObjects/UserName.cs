using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users.Errors;

namespace TaskManagerPractice.Domain.Users.ValueObjects;

public record UserName
{
    public string Value { get; }

    private UserName(string value) => Value = value;
    
    public static Result<UserName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Fail<UserName>(UserNameErrors.NameIsEmpty);
        
        if (value.Length is > 50 or < 3)
            return Result.Fail<UserName>(UserNameErrors.InvalidLength);
        
        return Result.Ok(new UserName(value));
    }
}