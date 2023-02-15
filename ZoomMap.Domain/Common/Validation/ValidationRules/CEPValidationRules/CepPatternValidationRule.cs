using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationRules.CEPValidationRules
{
    public class CepPatternValidationRule : IValidationRule<CEP>
    {
        private Error _error = Errors.Errors.CEP.InvalidPostalCodePattern;
        private const string PATTERN = @"^\d{8}$";

        public Result<CEP> Validate(CEP entity)
        {
            return new RegularExpressionValidationRule<CEP>(
                x => x.Code,
                PATTERN,
                _error
            ).Validate(entity);
        }
    }
}
