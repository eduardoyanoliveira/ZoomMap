using ZoomMap.Domain.Common.Events;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Events
{
    public interface IHandler<T> where T : IEvent
    {
        Task<Result<string>> Handle(T domainEvent);
    }
}
