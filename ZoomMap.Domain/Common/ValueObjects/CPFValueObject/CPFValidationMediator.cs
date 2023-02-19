using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects.CPFValueObject.CPFValidationRules;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.CPFValueObject
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
                        x => x.Value , Errors.CPF.EmptyCPF
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
