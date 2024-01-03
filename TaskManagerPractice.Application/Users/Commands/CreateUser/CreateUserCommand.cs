using MediatR;
using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.SharedKernel.Result;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email) : IRequest<Result<UserId>>;