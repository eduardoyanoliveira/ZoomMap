using ZoomMap.Domain.Common.ValueObjects.NeighbourhoodValueObject;

namespace DomainTests.ValueObjectTests
{
    public class NeighbourhoodTests
    {
        [Fact]
        public void ShouldCreateNeighbourhoodWithValidName()
        {
            // Arrange
            var name = "Neighbourhood 1";

            // Act
            var result = Neighbourhood.Create(name);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(name, result.GetValue().Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFailToCreateNeighbourhoodWithInvalidName(string name)
        {
            // Arrange & Act
            var result = Neighbourhood.Create(name);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void ShouldCompareNeighbourhoodsWithSameNameAsEqual()
        {
            // Arrange
            var neighbourhood1 = Neighbourhood.Create("Neighbourhood 1").GetValue();
            var neighbourhood2 = Neighbourhood.Create("Neighbourhood 1").GetValue();

            // Act
            var areEqual = neighbourhood1.Equals(neighbourhood2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void ShouldCompareNeighbourhoodsWithDifferentNameAsNotEqual()
        {
            // Arrange
            var neighbourhood1 = Neighbourhood.Create("Neighbourhood 1").GetValue();
            var neighbourhood2 = Neighbourhood.Create("Neighbourhood 2").GetValue();

            // Act
            var areEqual = neighbourhood1.Equals(neighbourhood2);

            // Assert
            Assert.False(areEqual);
        }
    }
}
