using ZoomMap.Domain.Common.ValueObjects;

namespace DomainTests.ValueObjectTests
{
    public class CityTests
    {
        [Fact]
        public void ShouldCreateCityWithValidName()
        {
            // Arrange
            var name = "City 1";

            // Act
            var result = City.Create(name);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(name, result.GetValue().Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldFailToCreateCityWithInvalidName(string name)
        {
            // Arrange & Act
            var result = City.Create(name);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void ShouldCompareCitiesWithSameNameAsEqual()
        {
            // Arrange
            var city1 = City.Create("City 1").GetValue();
            var city2 = City.Create("City 1").GetValue();

            // Act
            var areEqual = city1.Equals(city2);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void ShouldCompareCitiesWithDifferentNameAsNotEqual()
        {
            // Arrange
            var city1 = City.Create("City 1").GetValue();
            var city2 = City.Create("City 2").GetValue();

            // Act
            var areEqual = city1.Equals(city2);

            // Assert
            Assert.False(areEqual);
        }
    }
}
