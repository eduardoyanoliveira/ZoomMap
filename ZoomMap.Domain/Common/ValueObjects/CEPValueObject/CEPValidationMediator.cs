using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects.CEPValueObject.CEPValidationRules;

namespace ZoomMap.Domain.Common.ValueObjects.CEPValueObject
{
    public class CEPValidationMediator : IValidationMediator<CEP>
    {
        private readonly ValidationMediator<CEP> _validationMediator;

        private CEPValidationMediator(ValidationMediator<CEP> mediator)
        {
            _validationMediator = mediator;
        }

        public static CEPValidationMediator Create()
        {
            ValidationMediator<CEP> mediator = new ValidationMediator<CEP>(
                new List<IValidationRule<CEP>>
                {
                    new CepPatternValidationRule()
                }
            );

            return new CEPValidationMediator(mediator);
        }

        public Result<CEP> ValidateBatch(CEP entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
