using System.Text.RegularExpressions;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users.Errors;

namespace TaskManagerPractice.Domain.Users.ValueObjects;

public partial record Email
{
    private Email(string value) => Value = value;
    public string Value { get;}
    
    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Fail<Email>(EmailErrors.EmailIsEmpty);
        
        if (!EmailRegex().IsMatch(value))
            return Result.Fail<Email>(EmailErrors.InvalidFormat);
        
        return Result.Ok(new Email(value));
    }

    [GeneratedRegex(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
    private static partial Regex EmailRegex();
}