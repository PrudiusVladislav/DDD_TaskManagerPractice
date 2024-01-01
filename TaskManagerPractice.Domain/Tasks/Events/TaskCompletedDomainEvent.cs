using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.ValueObjects;

namespace TaskManagerPractice.Domain.Tasks.Events;

public record TaskCompletedDomainEvent(Guid Id, DateTime OccurredAt, TaskId CompletedTaskId)
    : DomainEvent(Id, OccurredAt);