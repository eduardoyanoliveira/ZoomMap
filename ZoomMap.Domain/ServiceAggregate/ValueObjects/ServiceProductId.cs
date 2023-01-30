using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.ServiceAggregate.ValueObjects
{
    public sealed class ServiceProductId : ValueObject
    {
        public Guid Value { get; }

        private ServiceProductId(Guid value)
        {
            Value = value;
        }
        public static ServiceProductId CreateUnique() => new ServiceProductId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
