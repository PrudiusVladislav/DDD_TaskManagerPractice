using TaskManagerPractice.Domain.Users.Exceptions;

namespace TaskManagerPractice.Domain.Users;

public record UserName
{
    public string Value { get; }

    private UserName(string value) => Value = value;
    
    public static UserName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw InvalidUserNameException.NameIsEmpty();
        if (value.Length is > 50 or < 3)
            throw InvalidUserNameException.InvalidLength();
        return new UserName(value);
    }
}