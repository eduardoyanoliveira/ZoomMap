namespace ZoomMap.Domain.Common.Events;

public interface IEvent
{
    string Name { get; }
    DateTime OccurredOn { get; }
}
