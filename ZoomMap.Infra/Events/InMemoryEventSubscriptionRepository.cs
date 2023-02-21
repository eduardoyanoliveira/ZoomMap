using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Infra.Events
{
    public sealed class InMemoryEventSubscriptionRepository : IEventSubscriptionRepository
    {

        private readonly List<Subscription> _subscriptions;

        public InMemoryEventSubscriptionRepository(List<Subscription> subscriptions = null)
        {
            _subscriptions = subscriptions ?? new();
        }

        public void Subscribe(
            Guid subscriberId,
            BaseDomainEvent baseDomainEvent,
            string typeId
        )
        {
            if (IsAlreadySubscribed(subscriberId, baseDomainEvent))
            {
                throw new ArgumentException(
                   $"There is already a subscription to the object with Id: {subscriberId} to this event."
                );
            }

            Subscription subscription = new Subscription(
                subscriberId,
                baseDomainEvent.Key,
                DateTime.Now,
                typeId
            );

            _subscriptions.Add(subscription);
        }
        public void Unsubscribe(Guid subscriberId, BaseDomainEvent baseDomainEvent)
        {
            if(IsAlreadySubscribed(subscriberId, baseDomainEvent))
            {
                throw new ArgumentException(
                  $"No subscription was found on database for this event and this subscriber."
                );
            }

            _subscriptions.RemoveAll(
                s => s.SubscriberId == subscriberId && s.EventKey == baseDomainEvent.Key
            );
        }

        public List<Subscription> GetSubscribersByEvent(BaseDomainEvent baseDomainEvent)
        {
            return _subscriptions.Where(
               s => s.EventKey == baseDomainEvent.Key
            ).ToList();
        }

        private bool IsAlreadySubscribed(Guid subscriberId, BaseDomainEvent baseDomainEvent)
        {
            return _subscriptions.Any(s => s.SubscriberId == subscriberId && s.EventKey == baseDomainEvent.Key);
        }
    }
}
