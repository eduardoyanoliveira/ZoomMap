namespace ZoomMap.Application.Interfaces.Events
{
    public interface IEventHandlersService
    {
        List<Func<IHandler<IEvent>>> GetHandlersForEvent(IEvent @event);
    }
}
