using MediatR;
using TaskManagerPractice.Domain.SharedKernel;

namespace TaskManagerPractice.Application.Users.Queries.GetAllUsers;

public record GetAllUsersQuery(): IRequest<IReadOnlyCollection<UserDto>>;