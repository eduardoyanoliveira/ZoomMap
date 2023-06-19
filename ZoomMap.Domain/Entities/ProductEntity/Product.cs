using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;

namespace ZoomMap.Domain.Entities.ProductEntity
{
    public sealed class Product : Entity<ProductId>
    {

        public string Name { get; }
        public double Price { get; }

        private static readonly IValidationMediator<Product> _validationMediator 
            = ProductValidationMediator.Create();

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

        public static Result<Product> Create(
            string name,
            double price
        )
        {
            Product product = new Product(
                ProductId.CreateUnique(),
                name,
                price
            );

            return _validationMediator.ValidateBatch( product );

        }

        public static Result<Product> Create(
            string productId,
            string name,
            double price
        )
        {
            ProductId id = ProductId.FromString<ProductId>(productId);
            Product product = new Product(
                id,
                name,
                price
            );

            return _validationMediator.ValidateBatch(product);
        }
    }
}
