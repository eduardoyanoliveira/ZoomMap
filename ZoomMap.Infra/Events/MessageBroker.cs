using ZoomMap.Application.Interfaces.Events;
using ZoomMap.Domain.Common.Events;

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
               handler.Invoke().Handle(@event);
            }

            //LogEvent(@event);
        }


    }
}
