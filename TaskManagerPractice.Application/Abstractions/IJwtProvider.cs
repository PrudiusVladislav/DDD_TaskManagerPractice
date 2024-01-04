using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Abstractions;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}