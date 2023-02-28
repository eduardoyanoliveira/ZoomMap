using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity;

namespace DomainTests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Create_ShouldFail_WhenNameIsEmpty()
        {
            // Arrange
            string name = "";
            double price = 1.99;

            // Act
             Result<Product> result = Product.Create(name, price);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(Errors.Product.EmptyOrNullProductName, result.Error);
        }

        [Fact]
        public void Create_ShouldFail_WhenPriceIsLessThanOrEqualToZero()
        {
            // Arrange
            string name = "Test Product";
            double price = 0;

            // Act
            Result<Product> result = Product.Create(name, price);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(Errors.Product.NotGreaterThanZeroPrice, result.Error);
        }

        [Fact]
        public void Create_ShouldSucceed_WhenNameAndPriceAreValid()
        {
            // Arrange
            string name = "Test Product";
            double price = 1.99;

            // Act
            var result = Product.Create(name, price);

            // Assert
            Assert.NotNull(result.GetValue());
            Assert.Equal(name, result.GetValue().Name);
            Assert.Equal(price, result.GetValue().Price);
        }
    }
}
