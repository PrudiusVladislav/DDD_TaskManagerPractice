using MediatR;

namespace TaskManagerPractice.Domain.SharedKernel;

public abstract class Entity<TId> : IHasDomainEvents
    where TId : TypedIdBase
{
    private readonly List<DomainEvent> _domainEvents = [];
    
    public TId Id { get; protected set; }
    
    public IReadOnlyCollection<DomainEvent> DomainEvents => 
        _domainEvents.AsReadOnly();
    
    protected void Raise(DomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }
    
    protected void RemoveDomainEvent(DomainEvent eventItem)
    {
        _domainEvents.Remove(eventItem);
    }
    
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}