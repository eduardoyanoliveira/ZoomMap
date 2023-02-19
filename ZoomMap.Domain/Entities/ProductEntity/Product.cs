using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ProductEntity
{
    public sealed class Product : Entity<ProductId>
    {

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
