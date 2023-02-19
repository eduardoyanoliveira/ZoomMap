using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;

namespace ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate.ValueObjects
{
    public sealed class DetachedProduct : ValueObject
    {
        public ProductId ProductId { get; }

        // Todo: Implement a way that if the Price is not given, it would take the price from ProductEntity
        public double? Price { get; }
        public int Quantity { get; }

        private DetachedProduct(
            ProductId productId,
            double? price,
            int quantity
        )
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public static DetachedProduct Create(
            ProductId productId,
            double? price,
            int quantity
        )
        {
            return new DetachedProduct(
                productId,
                price,
                quantity
            );
        }

        public double GetSubtotal()
        {
            return Quantity * (double)Price;
        }


        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductId.GetHashCode();
            yield return Price;
            yield return Quantity;
        }
    }
}
