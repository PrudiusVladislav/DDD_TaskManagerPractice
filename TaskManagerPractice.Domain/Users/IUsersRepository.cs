namespace TaskManagerPractice.Domain.Users;

public interface IUsersRepository
{
    Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(UserId userId, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(UserName userName, CancellationToken cancellationToken);
}