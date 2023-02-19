using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.ProductEntity;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ServiceEntity.ValueObjects
{
    public sealed class ServiceProduct : ValueObject
    {
        public ProductId ProductId { get; }
        public double Price { get; }
        public int Quantity { get; }

        private ServiceProduct(
            ProductId productId,
            double price,
            int quantity
        )
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        private ServiceProduct(
            Product product,
            double? price,
            int quantity
        )
        {
            ProductId = product.Id;
            Price = price ?? product.Price;
            Quantity = quantity;
        }

        public static ServiceProduct Create(
            ProductId productId,
            double price,
            int quantity
        )
        {
            return new ServiceProduct(
                productId,
                price,
                quantity
            );
        }

        public static ServiceProduct Create(
           Product product,
           double? price,
           int quantity
        )
        {
            return new ServiceProduct(
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
