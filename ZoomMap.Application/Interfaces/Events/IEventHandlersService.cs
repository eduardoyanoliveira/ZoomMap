namespace ZoomMap.Application.Interfaces.Events
{
    public interface IEventHandlersService
    {
        List<IHandler<IEvent>> GetHandlersForEvent(IEvent @event);
    }
}
