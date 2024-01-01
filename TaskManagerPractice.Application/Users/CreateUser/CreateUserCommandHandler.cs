using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Users.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Result<User>>
{
    private readonly IUsersRepository _usersRepository;
    
    public CreateUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userName = UserName.Create(request.Name);
        if (await _usersRepository.ExistsByNameAsync(userName, cancellationToken))
        {
            return Result<User>.Fail($"User with name {userName.Value} already exists");
        }
        
        var email = Email.Create(request.Email);
        if (await _usersRepository.ExistsByEmailAsync(email, cancellationToken))
        {
            return Result<User>.Fail($"The email {email.Value} is already in use");
        }
        var user = User.Create(TypedIdBase.New<UserId>(), userName, email);
        
        await _usersRepository.AddAsync(user, cancellationToken);
        return Result<User>.Ok(user);
    }
}