using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.ValueObjects;
using TaskManagerPractice.Domain.Users;

namespace TaskManagerPractice.Domain.Tasks.Events;

public record TaskCreatedDomainEvent(Guid Id, DateTime OccurredAt, TaskId CreatedTaskId, UserId AssignedUserId)
    : DomainEvent(Id, OccurredAt);