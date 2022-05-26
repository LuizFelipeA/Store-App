using OrderContext.Entities;
using SharedContext.Events;

namespace OrderContext.Events;

public class OrderCreatedEvent : IDomainEvent
{
    public OrderCreatedEvent(
        Order order)
    {
        Id = Guid.NewGuid();
        Order = order;
        OccuredAt = DateTime.Now;
    }
    
    public Order Order { get; }

    public Guid Id { get; set; }

    public DateTime OccuredAt { get; set; }
}
