using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Domain.Users.Errors;

public static class UserCredentialsErrors
{
    public static Error InvalidCredentials 
        => new Error(ErrorType.Unauthorized, "Invalid credentials");
}