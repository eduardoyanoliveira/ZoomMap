using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.ValidationRules.CPFValidationRules;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationMediators
{
    public class CPFValidationMediator : IValidationMediator<CPF>
    {
        private readonly ValidationMediator<CPF> _validationMediator;

        private CPFValidationMediator(ValidationMediator<CPF> validationMediator)
        {
            _validationMediator = validationMediator;
        }

        public static CPFValidationMediator Create()
        {
            ValidationMediator<CPF> validationMediator = new ValidationMediator<CPF>(
                new List<IValidationRule<CPF>>
                {
                    new NotEmptyValidationRule<CPF>(
                        x => x.Value , Errors.Errors.CPF.EmptyCPF
                    ),
                    new CPFLengthValidationRule(),
                    new CPFSequentialValidationRule(),
                    new CPFBaseValidationRule()
                }
            );

            return new CPFValidationMediator(validationMediator);
        }

        public Result<CPF> ValidateBatch(CPF entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
