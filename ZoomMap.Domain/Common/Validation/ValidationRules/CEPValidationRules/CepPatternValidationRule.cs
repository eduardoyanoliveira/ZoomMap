using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;
using ZoomMap.Domain.Validation.Errors;

namespace ZoomMap.Domain.Common.Validation.ValidationRules.CEPValidationRules
{
    public class CepPatternValidationRule : IValidationRule<CEP>
    {
        private readonly Error _error;
        private const string _pattern = @"^\d{8}$";

        public CepPatternValidationRule()
        {
            _error = Errors.CEP.InvalidPostalCodePattern;

        }


        public Result<CEP> Validate(CEP entity)
        {
            return new RegularExpressionValidationRule<CEP>(
                x => x.Code,
                _pattern,
                _error
            ).Validate(entity);
        }
    }
}
