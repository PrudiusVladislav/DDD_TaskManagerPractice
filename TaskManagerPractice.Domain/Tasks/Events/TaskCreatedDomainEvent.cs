using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.ValueObjects;

namespace TaskManagerPractice.Domain.Tasks.Events;

public record TaskCreatedDomainEvent(Guid Id, DateTime OccurredAt, TaskId CreatedTaskId)
    : DomainEvent(Id, OccurredAt);