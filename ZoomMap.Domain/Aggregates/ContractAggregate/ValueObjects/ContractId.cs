using ZoomMap.Domain.Common.Models;

namespace ZoomMap.Domain.Aggregates.ContractAggregate.ValueObjects
{
    public sealed class ContractId : ValueObject
    {
        public Guid Value { get; }

        private ContractId(Guid value)
        {
            Value = value;
        }
        public static ContractId CreateUnique() => new ContractId(Guid.NewGuid());

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
