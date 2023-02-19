using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.ProductEntity;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;

namespace ZoomMap.Domain.Aggregates.ServiceAppointmentAggregate.ValueObjects
{
    public sealed class DetachedProduct : ValueObject
    {
        public ProductId ProductId { get; }
        public double Price { get; }
        public int Quantity { get; }

        private DetachedProduct(
            ProductId productId,
            double price,
            int quantity
        )
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        private DetachedProduct(
            Product product,
            double? price,
            int quantity
        ) 
        { 
            ProductId = product.Id;
            Quantity = quantity;
            Price = price ?? product.Price;
        }

        public static DetachedProduct Create(
            ProductId productId,
            double price,
            int quantity
        )
        {
            return new DetachedProduct(
                productId,
                price,
                quantity
            );
        }

        public static DetachedProduct Create(
            Product product,
            double? price,
            int quantity
        )       
        {
            return new DetachedProduct(
                product,
                price,
                quantity
            );
        }

        public double GetSubtotal()
        {
            return Quantity * Price;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductId.GetHashCode();
            yield return Price;
            yield return Quantity;
        }
    }
}
