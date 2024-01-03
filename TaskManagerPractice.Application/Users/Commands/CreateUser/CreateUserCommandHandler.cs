using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users;
using TaskManagerPractice.Domain.Users.ValueObjects;

namespace TaskManagerPractice.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, Result<UserId>>
{
    private readonly UsersDomainService _usersDomainService;
    private readonly IUsersRepository _usersRepository;
    private readonly ILogger<CreateUserCommandHandler> _logger;
    
    public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
        IUsersRepository usersRepository, UsersDomainService usersDomainService)
    {
        _usersDomainService = usersDomainService;
        _usersRepository = usersRepository;
        _logger = logger;
    }
    
    public async Task<Result<UserId>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userNameResult = await _usersDomainService.CreateUserNameAsync(request.Name, cancellationToken);
        var emailResult = await _usersDomainService.CreateEmailAsync(request.Name, cancellationToken);
        
        var result = Result.Merge<UserId>(userNameResult, emailResult);
        if (result.IsFailure) return result;
        
        var user = User.Create(TypedIdBase.New<UserId>(),
            userNameResult.Value!, emailResult.Value!);
        await _usersRepository.AddAsync(user, cancellationToken);
        return Result.Ok(user.Id);
    }
}