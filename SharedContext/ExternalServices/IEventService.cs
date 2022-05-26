using SharedContext.Events;
namespace SharedContext.ExternalServices;

public interface IEventService
{
    public void Queue(IDomainEvent evt);
}
