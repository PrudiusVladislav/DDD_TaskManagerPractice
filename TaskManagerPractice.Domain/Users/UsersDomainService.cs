using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users.Errors;
using TaskManagerPractice.Domain.Users.ValueObjects;

namespace TaskManagerPractice.Domain.Users;

public class UsersDomainService
{
    private readonly IUsersRepository _usersRepository;

    public UsersDomainService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<UserName>> CreateUserNameAsync(string value, CancellationToken cancellationToken)
    {
        var userNameResult = UserName.Create(value);
        if (userNameResult.IsFailure)
            return userNameResult;
        
        var users = await _usersRepository.GetAllAsync(cancellationToken);
        if (users.Any(x => x.Name == userNameResult.Value))
            return userNameResult.AddError(UserNameErrors.NameIsNotUnique(userNameResult.Value!.Value));
        
        return Result.Ok(userNameResult.Value!);
    }
    
    public async Task<Result<Email>> CreateEmailAsync(string value, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(value);
        if (emailResult.IsFailure)
            return emailResult;
        
        var users = await _usersRepository.GetAllAsync(cancellationToken);
        if (users.Any(x => x.Email == emailResult.Value))
            return emailResult.AddError(EmailErrors.EmailIsNotUnique(emailResult.Value!.Value));
        
        return Result.Ok(emailResult.Value!);
    }
}