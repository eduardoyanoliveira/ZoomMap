using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ServiceEntity
{
    public sealed class Service : AggregateRoot<ServiceId>
    {
        private List<ServiceProduct> _serviceProducts = new();
        public IReadOnlyList<ServiceProduct> ServiceProducts => _serviceProducts.AsReadOnly();

        public string Name { get; }

        public double ServicePrice { get; }

        private Service(
            ServiceId serviceId,
            string name,
            double servicePrice,
            List<ServiceProduct>? serviceProducts
        )
            : base(serviceId)
        {
            Name = name;
            ServicePrice = servicePrice;
            _serviceProducts = serviceProducts ?? new();
        }

        public static Service Create(
            string name,
            double servicePrice,
            List<ServiceProduct>? serviceProducts
        )
        {
            return new Service(
                ServiceId.CreateUnique(),
                name,
                servicePrice,
                serviceProducts
            );
        }
    }
}
