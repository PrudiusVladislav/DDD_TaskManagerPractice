using TaskManagerPractice.Domain.SharedKernel;

namespace TaskManagerPractice.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid Id, DateTime OccurredAt, UserId CreatedUserId)
    : DomainEvent(Id, OccurredAt);