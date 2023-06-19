using ZoomMap.Application.Events.DomainEventHandlers.ServiceHandlers;
using ZoomMap.Application.Interfaces.Events;
using ZoomMap.Domain.Common.Events;
using ZoomMap.Domain.Entities.ProductEntity.DomainEvents;

namespace ZoomMap.Infra.Events
{
    public class EventHandlersService : IEventHandlersService
    {
        private readonly Dictionary<Type, List<Func<IHandler<IEvent>>>> _handlerLists = 
            new Dictionary<Type, List<Func<IHandler<IEvent>>>>();

        public EventHandlersService()
        {
            // Initialize handler subscriptions

            //var productPriceChangedEventHandlers = new List<Func<IHandler<ProductPriceChangedEvent>>>
            //{
            //    () => new ServiceHandlerProductPriceChangedEvent(),
            //};
            //_handlerLists[typeof(ProductPriceChangedEvent)] = new HandlerList<ProductPriceChangedEvent>(productPriceChangedEventHandlers);

            //var orderPlacedHandlers = new List<IHandler<OrderPlacedEvent>>
            //{
            //    () => new OrderPlacedEmailNotificationHandler(),
            //    () => new OrderPlacedInventoryHandler()
            //};
            //_handlerLists[typeof(OrderPlacedEvent)] = new HandlerList<OrderPlacedEvent>(orderPlacedHandlers);
        }

        public List<Func<IHandler<IEvent>>> GetHandlersForEvent(IEvent @event)
        {
            var eventType = @event.GetType();
            var handlerList = new List<Func<IHandler<IEvent>>>();

            if (_handlerLists.ContainsKey(eventType))
            {
                handlerList = _handlerLists[eventType];
            }

            return handlerList;
        }
    }
}
