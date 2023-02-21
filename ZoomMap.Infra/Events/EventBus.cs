using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Infra.Events
{
    public class EventBus
    {
        // Todo: Implement EventLogRepository

        private readonly Dictionary<string, IRepository<object>> _repositories;   // Repositories
        private readonly IEventSubscriptionRepository _eventSubscriptionRepository;
        //private readonly EventLogRepository _eventLogRepository;

        public EventBus(
            Dictionary<string, IRepository<object>> repositories,
            IEventSubscriptionRepository eventSubscriptionRepository
           // EventLogRepository eventLogRepository
        )
        {
            _repositories = repositories;
            _eventSubscriptionRepository = eventSubscriptionRepository;
           // _eventLogRepository = eventLogRepository;
        }

        public void Subscribe(
            Guid subscriberId, 
            BaseDomainEvent @event,
            string typeId
        )
        {
            _eventSubscriptionRepository.Subscribe(subscriberId, @event, typeId);
        }

        public void Unsubscribe(Guid subscriberId, BaseDomainEvent @event)
        {
            _eventSubscriptionRepository.Unsubscribe(subscriberId, @event);
        }

        public async Task Publish<T>(T @event)
            where T : BaseDomainEvent
        {
            var subscribers = _eventSubscriptionRepository.GetSubscribersByEvent(@event);

            var distinctTypes = subscribers.Select(s => s.TypeId).Distinct().ToList();

            foreach ( var type in distinctTypes ) 
            {
                var repository = _repositories[type];

                foreach(var subscription in subscribers.Where(s => s.TypeId == type))
                {
                    var subscriber = repository.GetById(subscription.SubscriberId);

                    if(subscriber is IDomainEventHandler<BaseDomainEvent> eventHanlder)
                        await eventHanlder.Handle(@event);

                    repository.Update(subscriber);
                }
            }

            //try
            //{
            //    _eventLogRepository.Save(@event);
            //}
            //catch (Exception ex)
            //{
            //    _cacheSystem.Add(@event, ex);
            //}
        }
    }
}
