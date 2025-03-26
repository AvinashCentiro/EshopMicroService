namespace Orderling.Domain.Events;

public record OrderUpdatedEvent(Order order) : IDomainEvent;
