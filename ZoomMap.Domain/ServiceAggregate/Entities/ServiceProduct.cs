using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.ProductAggregate.ValueObjects;
using ZoomMap.Domain.ServiceAggregate.ValueObjects;

namespace ZoomMap.Domain.ServiceAggregate.Entities
{
    public sealed class ServiceProduct : Entity<ServiceProductId>
    {
        public ProductId ProductId { get; }
        public double? Price { get; }
        public int Quantity { get; }

        private ServiceProduct(
            ServiceProductId serviceProductId,
            ProductId productId,
            double? price,
            int quantity
        )
            : base(serviceProductId)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public static ServiceProduct Create(
            ProductId productId,
            double? price,
            int quantity
        )
        {
            return new ServiceProduct(
                ServiceProductId.CreateUnique(),
                productId,
                price,
                quantity
            );
        }
    }
}
