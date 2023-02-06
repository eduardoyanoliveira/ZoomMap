using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.ProductAggregate.ValueObjects;
using ZoomMap.Domain.ServiceAggregate.ValueObjects;

namespace ZoomMap.Domain.ProductAggregate
{
    public sealed class Product : AggregateRoot<ProductId>
    {
        private List<ServiceProductId> _serviceProducts = new();
        public IReadOnlyList<ServiceProductId> ServiceProducts => _serviceProducts.AsReadOnly();

        private List<DetachedProductId> _detachedProducts = new();
        public IReadOnlyList<DetachedProductId> DetachedProducts => _detachedProducts.AsReadOnly();

        public string Name { get; }
        public double Price { get; }

        private Product(
            ProductId productId,
            string name,
            double price
        )
            : base(productId)
        {
            Name = name;
            Price = price;
        }

        public static Product Create(
            string name,
            double price
        )
        {
            return new Product(
                ProductId.CreateUnique(),
                name,
                price
            );
        }
    }
}
