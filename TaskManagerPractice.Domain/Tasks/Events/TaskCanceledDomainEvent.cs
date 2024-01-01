using TaskManagerPractice.Domain.SharedKernel;
using TaskManagerPractice.Domain.Tasks.ValueObjects;

namespace TaskManagerPractice.Domain.Tasks.Events;

public record TaskCanceledDomainEvent(Guid Id, DateTime OccurredAt, TaskId CanceledTaskId)
    : DomainEvent(Id, OccurredAt);