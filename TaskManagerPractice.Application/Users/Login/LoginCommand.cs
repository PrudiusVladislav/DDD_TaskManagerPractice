using MediatR;
using TaskManagerPractice.Domain.SharedKernel.Result;

namespace TaskManagerPractice.Application.Users.Login;

public record LoginCommand(string Email): IRequest<Result<string>>;