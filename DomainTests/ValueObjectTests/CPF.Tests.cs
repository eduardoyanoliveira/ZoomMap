using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Common.ValueObjects.CPFValueObject;

namespace DomainTests.ValueObjectTests
{
    public class CPFTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void CPF_ShouldBeInvalid_WhenValueIsNull(string value)
        {
            var result = CPF.Create(value);

            Assert.True(result.IsFailure);
            Assert.Equal(Errors.CPF.EmptyCPF, result.Error);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("123456789012")]
        public void CPF_ShouldBeInvalid_WhenValueIsNot11Characters(string value)
        {
            var result = CPF.Create(value);

            Assert.True(result.IsFailure);
            Assert.Equal(Errors.CPF.CPFLength, result.Error);
        }

        [Theory]
        [InlineData("00000000000")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("33333333333")]
        [InlineData("44444444444")]
        [InlineData("55555555555")]
        [InlineData("66666666666")]
        [InlineData("77777777777")]
        [InlineData("88888888888")]
        [InlineData("99999999999")]
        public void CPF_ShouldBeInvalid_WhenValueIsNotUnique(string value)
        {
            var result = CPF.Create(value);

            Assert.True(result.IsFailure);
            Assert.Equal(Errors.CPF.CPFSequential, result.Error);
        }

        [Theory]
        [InlineData("12345678910")]
        [InlineData("12312312312")]
        public void CPF_WithInvalidNumbers_ShouldNotBeValid(string invalidCPF)
        {
            var result = CPF.Create(invalidCPF);
            Assert.True(result.IsFailure);
            Assert.Equal(Errors.CPF.InvalidValue, result.Error);
        }

        [Theory]
        [InlineData("96582743074")]
        [InlineData("09262998082")]
        [InlineData("47442259006")]
        public void CPF_ShouldBeValid(string value)
        {
            var result = CPF.Create(value);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.GetValue());
            Assert.Equal(value, result.GetValue().Value);
        }

        [Fact]
        public void CPF_ShouldCompareCPFsWithDifferentValuesAsNotEqual()
        {
            var CPF1 = CPF.Create("09262998082").GetValue().Value;
            var CPF2 = CPF.Create("47442259006").GetValue().Value;

            Assert.NotEqual(CPF1, CPF2);
        }

        [Fact]
        public void CPF_ShouldCompareCPFsWithSameValuesAsEqual()
        {
            var CPF1 = CPF.Create("09262998082").GetValue().Value;
            var CPF2 = CPF.Create("09262998082").GetValue().Value;

            Assert.Equal(CPF1, CPF2);
        }

        [Fact]
        public void CPF_ShouldHaveSameHashCodeForSameValues()
        {
            var CPF1 = CPF.Create("09262998082").GetValue().Value;
            var CPF2 = CPF.Create("09262998082").GetValue().Value;

            Assert.Equal(CPF1.GetHashCode(), CPF2.GetHashCode());
        }
    }
}
