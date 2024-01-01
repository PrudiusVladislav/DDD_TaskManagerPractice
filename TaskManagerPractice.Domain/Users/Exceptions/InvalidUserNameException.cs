namespace TaskManagerPractice.Domain.Users.Exceptions;

public class InvalidUserNameException: Exception
{
    private InvalidUserNameException(string? message) : base(message) { }
    
    public static InvalidUserNameException NameIsEmpty() 
        => new("Username can not be empty");
    
    public static InvalidUserNameException InvalidLength() 
        => new("Username must be between 3 and 50 characters");
}