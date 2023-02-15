using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationRules.CPFValidationRules
{
    internal class CPFLengthValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.Errors.CPF.CPFLength;
        private const int REQUIRED_LENGTH = 11;

        public Result<CPF> Validate(CPF entity)
        {
            if (entity.Value.Length != REQUIRED_LENGTH)
                return Result<CPF>.Fail(_error);

            return Result<CPF>.Ok(entity);
        }
    }
    
}
