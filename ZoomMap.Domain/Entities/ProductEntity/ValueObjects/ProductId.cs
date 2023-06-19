using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.Entities.ProductEntity.ValueObjects
{
    public sealed class ProductId : ValueObject
    {
        public Guid Value { get; }

        private ProductId(Guid value)
        {
            Value = value;
        }
        public static ProductId CreateUnique() => new ProductId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
