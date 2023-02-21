namespace ZoomMap.Domain.Common.Events
{
    public abstract class BaseDomainEvent
    {
        public string Key { get; }
        public DateTimeOffset Timestamp { get; }

        public BaseDomainEvent(string key)
        {
            Key = key;
            Timestamp = DateTimeOffset.Now;
        }
    }
}
