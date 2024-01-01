namespace TaskManagerPractice.Domain.Users.Exceptions;

public class InvalidEmailException: Exception
{
    private InvalidEmailException(string message)
        : base(message)
    {
    }
    
    public static InvalidEmailException EmptyEmail()
    {
        return new InvalidEmailException("Email cannot be empty");
    }
    
    public static InvalidEmailException InvalidFormat()
    {
        return new InvalidEmailException("Invalid email format");
    }
}