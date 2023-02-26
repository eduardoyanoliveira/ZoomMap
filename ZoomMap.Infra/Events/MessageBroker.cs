using ZoomMap.Application.Interfaces.Events;

namespace ZoomMap.Infra.Events
{
    public class MessageBroker : IMessageBroker
    {
        private readonly IEventHandlersService _eventHandlersService;

        public MessageBroker(IEventHandlersService eventHandlersService)
        {
            _eventHandlersService = eventHandlersService;
        }

        public void LogEvent(IEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Publish(IEvent @event)
        {
            var handlers =  _eventHandlersService.GetHandlersForEvent(@event);
            foreach (var handler in handlers)
            {
                var handlerType = handler.GetType();
                var handlerInstance = (IHandler<IEvent>)Activator.CreateInstance(handlerType);
                handlerInstance.Handle(@event);

               // handler.Handle(@event);
            }

            //LogEvent(@event);
        }


    }
}
