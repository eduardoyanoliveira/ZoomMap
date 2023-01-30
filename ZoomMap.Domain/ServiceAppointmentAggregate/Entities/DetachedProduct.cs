using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.ProductAggregate.ValueObjects;

namespace ZoomMap.Domain.ServiceAppointmentAggregate.Entities
{
    public sealed class DetachedProduct : Entity<DetachedProductId>
    {
        public ProductId ProductId { get; }

        public int Quantity { get; }

        public double? Price { get; }

        private DetachedProduct(
            DetachedProductId detachedProductId,
            ProductId productId,
            int quantity,
            double? price
        ) 
            : base(detachedProductId)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public static DetachedProduct Create(
            ProductId productId,
            int quantity,
            double? price
        )
        {
            return new DetachedProduct(
                DetachedProductId.CreateUnique(),
                productId,
                quantity,
                price);
        }
    }
}
