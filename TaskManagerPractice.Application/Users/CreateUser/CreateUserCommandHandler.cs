using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Users.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Result<UserId>>
{
    private readonly IUsersRepository _usersRepository;
    
    public CreateUserCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task<Result<UserId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userName = UserName.Create(request.Name);
        if (await _usersRepository.ExistsAsync(userName, cancellationToken))
        {
            return Result<UserId>.Fail($"User with name {userName} already exists");
        }
        
        var email = Email.Create(request.Email);
        var user = User.Create(new UserId(Guid.NewGuid()),userName, email);
        
        await _usersRepository.AddAsync(user, cancellationToken);
        return Result<UserId>.Ok(user.Id);
    }
}