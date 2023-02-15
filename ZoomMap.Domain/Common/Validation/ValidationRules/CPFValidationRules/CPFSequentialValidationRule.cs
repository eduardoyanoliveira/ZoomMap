using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationRules.CPFValidationRules
{
    public class CPFSequentialValidationRule : IValidationRule<CPF>
    {
        private Error _error = Errors.Errors.CPF.CPFSequential;
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
