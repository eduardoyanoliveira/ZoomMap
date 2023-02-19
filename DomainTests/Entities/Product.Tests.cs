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

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Product.Create(name, price));
        }

        [Fact]
        public void Create_ShouldFail_WhenPriceIsLessThanOrEqualToZero()
        {
            // Arrange
            string name = "Test Product";
            double price = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Product.Create(name, price));
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
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(price, result.Price);
        }
    }
}
