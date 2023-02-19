using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Common.ValueObjects.AddressValueObject;

namespace DomainTests.Factories
{
    public class AddressFactoryTests
    {
        [Fact]
        public void Create_ShouldFail_WhenLocationNumberIsLessThanOrEqualToZero()
        {
            // Arrange
            int locationNumber = 0;
            string cepValue = "12345678";
            string neighbourhoodName = "Test Neighbourhood";
            string street = "Test Street";
            string cityName = "Test City";
            // Act
            var result = AddressFactory.Create(locationNumber, cepValue, neighbourhoodName, street, cityName);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(Errors.Address.InvalidLocationNumber, result.Error);
        }

        [Fact]
        public void Create_ShouldFail_WhenStreetNameIsEmpty()
        {
            // Arrange
            int locationNumber = 1;
            string cepValue = "12345678";
            string neighbourhoodName = "Test Neighbourhood";
            string street = "";
            string cityName = "Test City";

            // Act
            var result = AddressFactory.Create(locationNumber, cepValue, neighbourhoodName, street, cityName);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(Errors.Address.NullOrEmptyStreetName, result.Error);
        }

        [Fact]
        public void Create_ShouldSucceed_WhenAllPropertiesAreValid()
        {
            // Arrange
            int locationNumber = 1;
            string cepValue = "12345678";
            string neighbourhoodName = "Test Neighbourhood";
            string street = "Test Street";
            string cityName = "Test City";

            // Act
            var result = AddressFactory.Create(locationNumber, cepValue, neighbourhoodName, street, cityName);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}