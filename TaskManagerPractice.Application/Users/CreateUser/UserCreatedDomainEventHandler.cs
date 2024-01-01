using MediatR;
using TaskManagerPractice.Domain.Users.Events;

namespace TaskManagerPractice.Application.Users.CreateUser;

public class UserCreatedDomainEventHandler: INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        
    }
}