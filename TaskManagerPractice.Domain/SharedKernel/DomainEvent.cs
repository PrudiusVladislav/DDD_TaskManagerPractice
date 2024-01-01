using MediatR;

namespace TaskManagerPractice.Domain.SharedKernel;

public abstract record DomainEvent(Guid Id, DateTime OccurredAt) : INotification;