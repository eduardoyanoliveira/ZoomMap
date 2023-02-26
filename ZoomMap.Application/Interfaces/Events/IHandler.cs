using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Application.Interfaces.Events
{
    public interface IHandler<T> where T : IEvent
    {
        void Handle(T domainEvent);
    }
}
