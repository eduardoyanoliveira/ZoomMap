using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate.ValueObjects
{
    public sealed class ServiceAppointmentId : ValueObject
    {
        public Guid Value { get; }

        private ServiceAppointmentId(Guid value)
        {
            Value = value;
        }
        public static ServiceAppointmentId CreateUnique() => new ServiceAppointmentId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
