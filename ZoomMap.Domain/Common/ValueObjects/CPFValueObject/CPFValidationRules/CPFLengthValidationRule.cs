using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.CPFValueObject.CPFValidationRules
{
    internal class CPFLengthValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.CPF.CPFLength;
        private const int REQUIRED_LENGTH = 11;

        public Result<CPF> Validate(CPF entity)
        {
            if (entity.Value.Length != REQUIRED_LENGTH)
                return Result<CPF>.Fail(_error);

            return Result<CPF>.Ok(entity);
        }
    }

}
