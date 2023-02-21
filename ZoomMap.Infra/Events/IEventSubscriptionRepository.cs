using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Infra.Events
{
    public interface IEventSubscriptionRepository
    {
        List<Subscription> GetSubscribersByEvent(BaseDomainEvent baseDomainEvent);
        void Subscribe(Guid subscriberId, BaseDomainEvent baseDomainEvent, string typeId);
        void Unsubscribe(Guid subscriberId, BaseDomainEvent baseDomainEvent);
    }
}
