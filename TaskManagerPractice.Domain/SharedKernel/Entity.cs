using MediatR;

namespace TaskManagerPractice.Domain.SharedKernel;

public abstract class Entity<TId> where TId : TypedIdBase
{
    private readonly List<INotification> _domainEvents = [];
    
    public TId Id { get; protected set; }
    
    public IReadOnlyCollection<INotification> DomainEvents => 
        _domainEvents.AsReadOnly();
    
    protected void Raise(INotification eventItem)
    {
        _domainEvents.Add(eventItem);
    }
    
    protected void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents.Remove(eventItem);
    }
    
    protected void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}