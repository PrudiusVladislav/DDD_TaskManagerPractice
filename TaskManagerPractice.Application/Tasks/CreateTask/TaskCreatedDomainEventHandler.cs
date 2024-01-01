using MediatR;
using TaskManagerPractice.Domain.Tasks.Events;

namespace TaskManagerPractice.Application.Tasks.CreateTask;

public class TaskCreatedDomainEventHandler: INotificationHandler<TaskCreatedDomainEvent>
{
    public async Task Handle(TaskCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        
    }
}