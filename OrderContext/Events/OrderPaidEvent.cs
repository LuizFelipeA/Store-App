using OrderContext.Entities;
using SharedContext.Events;

namespace OrderContext.Events;

public class OrderPaidEvent : IDomainEvent
{
    public OrderPaidEvent(Order order)
    {
        Order = order;
    }

    public Guid Id { get; set; }

    public Order Order { get; set; }
    
    public DateTime OccuredAt { get; set; }
}
