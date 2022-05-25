namespace SharedContext.ExternalServices;

public interface IEventService
{
    public Task QueueAsync(IDomainEvent evt);
}
