using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Users.CreateUser;

public record CreateUserCommand(string Name, string Email) : IRequest<Result<User>>;