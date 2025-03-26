
namespace Orderling.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainevents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainevents.AsReadOnly();


    public void  AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainevents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        IDomainEvent[] dequeueEvents=_domainevents.ToArray();

        _domainevents.Clear();
        return dequeueEvents;
    }
}
