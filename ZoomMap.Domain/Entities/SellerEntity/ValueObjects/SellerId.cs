using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.Entities.SellerEntity.ValueObjects
{
    public sealed class SellerId : ValueObject
    {
        public Guid Value { get; }

        private SellerId(Guid value)
        {
            Value = value;
        }
        public static SellerId CreateUnique() => new SellerId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
