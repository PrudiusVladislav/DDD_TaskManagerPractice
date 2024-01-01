namespace TaskManagerPractice.Domain.Tasks.Exceptions;

public class InvalidTaskLifeRangeException: Exception
{
    private InvalidTaskLifeRangeException(string message)
        : base(message)
    {
    }
    
    public static InvalidTaskLifeRangeException CreatedAtGreaterThanCompletedAt()
    {
        return new InvalidTaskLifeRangeException("Invalid task life range: CompletedAt must be greater than CreatedAt.");
    }
}