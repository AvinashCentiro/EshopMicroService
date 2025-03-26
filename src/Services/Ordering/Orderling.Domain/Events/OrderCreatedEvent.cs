using System.Threading.Tasks;

namespace Orderling.Domain.Events;

public record OrderCreatedEvent(Order order) : IDomainEvent;
