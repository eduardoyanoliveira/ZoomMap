using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.ValidationRules.CEPValidationRules;

namespace ZoomMap.Domain.Common.Validation.ValidationMediators
{
    public class CEPValidationMediator<CEP>
    {
        private readonly ValidationMediator<CEP> _mediator;

        private CEPValidationMediator(ValidationMediator<CEP> mediator)
        {
            _mediator = mediator;
        }

        public static CEPValidationMediator<CEP> Create()
        {
            ValidationMediator<CEP> mediator = new ValidationMediator<CEP>(
                new List<IValidationRule<CEP>>
                {
                (IValidationRule<CEP>)new CepPatternValidationRule()
                }
            );

            return new CEPValidationMediator<CEP>(mediator);
        }

        public Result<CEP> Validate(CEP entity)
        {
            return _mediator.Validate(entity);
        }
    }
}
