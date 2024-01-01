using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.ValueObjects;

namespace TaskManagerPractice.Domain.Tasks.Events;

public record TaskUpdatedDomainEvent(Guid Id, DateTime OccurredAt, TaskId UpdatedTaskId)
    : DomainEvent(Id, OccurredAt);