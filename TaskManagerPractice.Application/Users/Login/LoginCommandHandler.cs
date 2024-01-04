using MediatR;
using TaskManagerPractice.Application.Abstractions;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users;
using TaskManagerPractice.Domain.Users.Errors;
using TaskManagerPractice.Domain.Users.ValueObjects;

namespace TaskManagerPractice.Application.Users.Login;

public class LoginCommandHandler: IRequestHandler<LoginCommand, Result<string>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IJwtProvider _jwtProvider;
    
    public LoginCommandHandler(IUsersRepository usersRepository, IJwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _jwtProvider = jwtProvider;
    }
    
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Get user
        var emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
            return Result.Merge<string>(emailResult);
        
        var user = await _usersRepository.GetByEmailAsync(emailResult.Value!, cancellationToken);
        if (user is null)
            return Result.Fail<string>(UserCredentialsErrors.InvalidCredentials);
        
        // Generate JWT
        var jwtToken = _jwtProvider.GenerateJwtToken(user);
        return Result.Ok(jwtToken);
    }
}