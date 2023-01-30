using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.ProductAggregate.ValueObjects
{
    public sealed class DetachedProductId : ValueObject
    {
        public Guid Value { get; }

        private DetachedProductId(Guid value)
        {
            Value = value;
        }
        public static DetachedProductId CreateUnique() => new DetachedProductId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
