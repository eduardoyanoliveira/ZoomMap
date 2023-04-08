using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Entities.ProductEntity;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ServiceEntity
{
    public sealed class Service : AggregateRoot<ServiceId>
    {
        private List<ServiceProduct> _serviceProducts = new();
        public IReadOnlyList<ServiceProduct> ServiceProducts => _serviceProducts.AsReadOnly();

        private static readonly IValidationMediator<Service> _validationMediator
            = ServiceValidationMediator.Create();

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

        public double CalculateTotalPrice()
        {
            var totalPrice = _serviceProducts.Sum(p => p.Price * p.Quantity) + ServicePrice;

            return totalPrice;
        }

        public static Result<Service> Create(
            string name,
            List<ServiceProduct>? serviceProducts,
            double? servicePrice = null
        )
        {
            Service service = new Service(
                ServiceId.CreateUnique(),
                name,
                servicePrice ?? 0,
                serviceProducts
            );

            return _validationMediator.ValidateBatch(service);
        }
    }
}
