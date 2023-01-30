using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.ServiceAggregate.ValueObjects
{
    public sealed class ServiceId : ValueObject
    {
        public Guid Value { get; }

        private ServiceId(Guid value)
        {
            Value = value;
        }
        public static ServiceId CreateUnique() => new ServiceId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
