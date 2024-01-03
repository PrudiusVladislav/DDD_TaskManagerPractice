using MediatR;
using TaskManagerPractice.Application.Shared;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, IReadOnlyCollection<UserDto>>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    
    public GetAllUsersQueryHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _usersRepository.GetAllAsync(cancellationToken);
        var userDtos = users.Select(_mapper.MapUserToUserDto).ToList();
        return userDtos;
    }
}