using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.CPFValueObject.CPFValidationRules
{
    public class CPFSequentialValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.CPF.CPFSequential;
        public Result<CPF> Validate(CPF entity)
        {
            if (!IsValid(entity.Value))
                return Result<CPF>.Fail(_error);

            return Result<CPF>.Ok(entity);
        }
        private bool IsValid(string cpf)
        {
            int distinctNumbers = cpf.Select(c => c - '0')
                .ToArray().Distinct().Count();

            return distinctNumbers > 1;
        }
    }
}
