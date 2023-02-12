using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Common.ValueObjects;

namespace DomainTests.ValueObjectTests
{
    public class CEPTests
    {
        [Theory]
        [InlineData("01234567")]
        [InlineData("12345678")]
        public void Create_ValidCEP_ShouldReturnSuccess(string code)
        {
            var result = CEP.Create(code);

            Assert.True(result.IsSuccess);
            Assert.Equal(code, result.GetValue().Code);
        }

        [Theory]
        [InlineData("012345670")]
        [InlineData("1234-56789")]
        [InlineData("1234-567a")]
        public void Create_InvalidCEP_ShouldReturnFailure(string code)
        {
            var result = CEP.Create(code);

            Assert.True(result.IsFailure);
            Assert.Equal(Errors.CEP.InvalidPostalCodePattern, result.Error);
        }
    }
}
