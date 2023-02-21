using ZoomMap.Domain.Common.Events;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ServiceEntity.DomainEvents
{
    public class ServiceTotalCalculatedEvent : BaseDomainEvent
    {
        public Guid ServiceId { get; }
        public double TotalPrice { get; }
        public ServiceTotalCalculatedEvent(
            ServiceId serviceId, 
            double totalPrice
        )
            : base("ServiceTotalCalculatedEvent")
        {
            ServiceId = serviceId.Value;
            TotalPrice = totalPrice;
        }
    }
}
