using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Application.Interfaces.Events
{
    public interface IMessageBroker
    {
        void Publish(IEvent @event);
        void LogEvent(IEvent @event);
    }
}
