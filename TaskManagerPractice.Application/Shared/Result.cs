namespace TaskManagerPractice.Application.Shared;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string Error { get; }

    private Result(bool isSuccess, T? value, string error)
    {
        if (isSuccess && error != string.Empty ||
            !isSuccess && error == string.Empty)
        {
            throw new InvalidOperationException();
        }
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }

    public static Result<T> Ok(T value)
    {
        return new Result<T>(true, value, string.Empty);
    }

    public static Result<T> Fail(string error)
    {
        return new Result<T>(false, default(T), error);
    }
}
