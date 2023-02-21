namespace ZoomMap.Domain.Common.Events
{
    public interface IDomainEventHandler<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
