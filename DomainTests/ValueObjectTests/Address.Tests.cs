using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Common.ValueObjects.AddressValueObject;
using ZoomMap.Domain.Common.ValueObjects.CEPValueObject;
using ZoomMap.Domain.Common.ValueObjects.CityValueObject;
using ZoomMap.Domain.Common.ValueObjects.NeighbourhoodValueObject;

namespace DomainTests.ValueObjectTests
{
    public class AddressTests
    {
        [Fact]
        public void Create_AddressWithLocationNumberEqualOrLessThanZero_ReturnsInvalidResult()
        {
            // Arrange
            int invalidLocationNumber = 0;
            Result<CEP> cep = CEP.Create("12345678");
            Result<Neighbourhood> neighbourhood = Neighbourhood.Create("Test Neighbourhood");
            string street = "Test Street";
            Result<City> city = City.Create("Test City");

            // Act
            Result<Address> result = Address.Create(
                invalidLocationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(Errors.Address.InvalidLocationNumber, result.Error);
        }

        [Fact]
        public void Create_AddressWithEmptyStreetName_ReturnsInvalidResult()
        {
            // Arrange
            int locationNumber = 80;
            Result<CEP> cep = CEP.Create("12345678");
            Result<Neighbourhood> neighbourhood = Neighbourhood.Create("Test Neighbourhood");
            string invalidStreet = "";
            Result<City> city = City.Create("Test City");

            // Act
            Result<Address> result = Address.Create(
                locationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                invalidStreet,
                city.GetValue()
            );

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(Errors.Address.NullOrEmptyStreetName, result.Error);
        }

        [Fact]
        public void Create_Address_ReturnsValidResult()
        {
            // Arrange
            int locationNumber = 80;
            Result<CEP> cep = CEP.Create("12345678");
            Result<Neighbourhood> neighbourhood = Neighbourhood.Create("Test Neighbourhood");
            string street = "Test Street";
            Result<City> city = City.Create("Test City");

            // Act
            Result<Address> result = Address.Create(
                locationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Address_ShouldCompareAddresesWithDifferetValuesAsNotEqua()
        {
            // Arrange
            int locationNumber = 80;
            Result<CEP> cep = CEP.Create("12345678");
            Result<Neighbourhood> neighbourhood = Neighbourhood.Create("Test Neighbourhood");
            string street = "Test Street";
            Result<City> city = City.Create("Test City");

            // Act
            Result<Address> address1 = Address.Create(
                locationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Act
            Result<Address> address2 = Address.Create(
                90,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Assert
            Assert.NotEqual(address1.GetValue(), address2.GetValue());
        }

        [Fact]
        public void Address_ShouldCompareAddresesWithSameValuesAsEqua()
        {
            // Arrange
            int locationNumber = 80;
            Result<CEP> cep = CEP.Create("12345678");
            Result<Neighbourhood> neighbourhood = Neighbourhood.Create("Test Neighbourhood");
            string street = "Test Street";
            Result<City> city = City.Create("Test City");

            // Act
            Result<Address> address1 = Address.Create(
                locationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Act
            Result<Address> address2 = Address.Create(
                locationNumber,
                cep.GetValue(),
                neighbourhood.GetValue(),
                street,
                city.GetValue()
            );

            // Assert
            Assert.Equal(address1.GetValue(), address2.GetValue());
        }
    }
}
