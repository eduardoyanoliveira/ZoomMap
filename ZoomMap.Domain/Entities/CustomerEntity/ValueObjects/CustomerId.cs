using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.Entities.CustomerEntity.ValueObjects
{
    public sealed class CustomerId : ValueObject
    {
        public Guid Value { get; }

        private CustomerId(Guid value)
        {
            Value = value;
        }
        public static CustomerId CreateUnique() => new CustomerId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
