using ZoomMap.Domain.Common.Events;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ServiceEntity.DomainEvents
{
    public class ServiceTotalCalculatedEvent : IEvent
    {
        public Guid ServiceId { get; }
        public double TotalPrice { get; }
        public string Name => "ServiceTotalCalculatedEvent";
        public DateTime OccurredOn => DateTime.Now;

        public ServiceTotalCalculatedEvent(
            ServiceId serviceId, 
            double totalPrice
        )
        {
            ServiceId = serviceId.Value;
            TotalPrice = totalPrice;
        }
    }
}
