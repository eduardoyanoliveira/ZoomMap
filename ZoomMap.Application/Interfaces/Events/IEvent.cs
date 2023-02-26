namespace ZoomMap.Application.Interfaces.Events
{
    public interface IEvent
    {
        string Name { get; }
        DateTime OccurredOn { get; }
    }
}
