using MediatR;
using TaskManagerPractice.Domain.Tasks.Events;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Application.Tasks.Commands.CreateTask;

public class TaskCreatedDomainEventHandler: INotificationHandler<TaskCreatedDomainEvent>
{
    private readonly IUsersRepository _usersRepository;
    
    public TaskCreatedDomainEventHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    public async Task Handle(TaskCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        // var task = await 
        // var user = await _usersRepository.GetByIdAsync(notification., cancellationToken);
    }
}