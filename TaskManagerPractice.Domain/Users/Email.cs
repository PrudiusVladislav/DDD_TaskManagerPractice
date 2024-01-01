using System.Text.RegularExpressions;
using TaskManagerPractice.Domain.Users.Exceptions;

namespace TaskManagerPractice.Domain.Users;

public partial record Email
{
    private Email(string value) => Value = value;
    public string Value { get; init; }
    
    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw InvalidEmailException.EmptyEmail();
        }
        
        if (!EmailRegex().IsMatch(value))
        {
            throw InvalidEmailException.InvalidFormat();
        }
        
        return new Email(value);
    }

    [GeneratedRegex(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$")]
    private static partial Regex EmailRegex();
}