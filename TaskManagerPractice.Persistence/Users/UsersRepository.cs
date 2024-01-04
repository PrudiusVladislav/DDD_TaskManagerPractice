using Microsoft.EntityFrameworkCore;
using TaskManagerPractice.Domain.Users;
using TaskManagerPractice.Domain.Users.ValueObjects;
using Task = System.Threading.Tasks.Task;


namespace TaskManagerPractice.Persistence.Users;

public class UsersRepository: IUsersRepository
{
    private readonly TaskManagerDbContext _dbContext;
    
    public UsersRepository(TaskManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return (await _dbContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken))
            .AsReadOnly();
    }

    public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.Users.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        var userToUpdate = await _dbContext.Users.FindAsync([user.Id], cancellationToken: cancellationToken);
        if (userToUpdate is null) 
            throw new InvalidOperationException($"User with id {user.Id} not found");
        userToUpdate.UpdateName(user.Name);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(UserId userId, CancellationToken cancellationToken)
    {
        var userToDelete = await _dbContext.Users.FindAsync([userId], cancellationToken: cancellationToken);
        if (userToDelete is null) 
            return;
        _dbContext.Users.Remove(userToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}