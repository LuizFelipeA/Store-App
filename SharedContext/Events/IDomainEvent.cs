namespace SharedContext.Events;

public interface IDomainEvent
{
    public DateTime OccuredAt { get; set; }
}
