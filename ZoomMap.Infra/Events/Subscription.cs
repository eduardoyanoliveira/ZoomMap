namespace ZoomMap.Infra.Events
{
    public sealed class Subscription
    {
        public Guid SubscriberId { get; }
        public string EventKey { get; }
        public DateTime SubscribedAt { get; }
        public DateTime? UnsubscribedAt { get; set; }

        public string TypeId { get; }

        public Subscription(Guid subscriberId, string eventKey, DateTime subscribedAt, string typeId)
        {
            this.SubscriberId = subscriberId;
            this.EventKey = eventKey;
            this.SubscribedAt = subscribedAt;
            TypeId = typeId;    
        }

        public void Unsubscribe()
        {
            UnsubscribedAt = DateTime.Now;
        }
    }
}
