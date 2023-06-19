using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.CustomerEntity.ValueObjects;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;
using ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate.ValueObjects;

namespace ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate
{
    public sealed class ServiceAppointment : AggregateRoot<ServiceAppointmentId>
    {
        private List<DetachedProduct> _detachedProducts = new();
        public IReadOnlyList<DetachedProduct> DetachedProducts => _detachedProducts.AsReadOnly();

        private double? _serviceTotalPrice;

        public ServiceId ServiceId { get; }
        public CustomerId CustomerId { get; }
        public DateTime AppointmentDateTime { get; }
        public DateTime? ExecutionDateTime { get; }
        public string Obs { get; }

        private ServiceAppointment(
            ServiceAppointmentId serviceAppointmentId,
            ServiceId serviceId,
            CustomerId customerId,
            DateTime appointmentDateTime,
            DateTime? executionDateTime,
            string obs,
            List<DetachedProduct> detachedProducts
        )
            : base(serviceAppointmentId)
        {
            ServiceId = serviceId;
            CustomerId = customerId;
            AppointmentDateTime = appointmentDateTime;
            ExecutionDateTime = executionDateTime;
            Obs = obs;
            _detachedProducts = detachedProducts ?? new();
        }

        public static ServiceAppointment Create(
            ServiceId serviceId,
            CustomerId customerId,
            DateTime appointmentDateTime,
            DateTime? executionDateTime,
            string obs,
            List<DetachedProduct> detachedProducts = null
        )
        {
            return new ServiceAppointment(
                ServiceAppointmentId.CreateUnique(),
                serviceId,
                customerId,
                appointmentDateTime,
                executionDateTime,
                obs,
                detachedProducts
            );
        }

        public double GetTotalPrice()
        {
            var detachedProductsTotal = _detachedProducts.Sum(p => p.Quantity * p.Price);

            if (_serviceTotalPrice.HasValue)
            {
                return _serviceTotalPrice.Value + detachedProductsTotal;
            }

            return detachedProductsTotal;
        }
    }
}
