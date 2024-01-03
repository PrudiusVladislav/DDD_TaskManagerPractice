namespace TaskManagerPractice.Domain.SharedKernel.Result;

public record Error(ErrorType Type, string Message);