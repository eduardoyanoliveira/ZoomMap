using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.ValueObjects;

namespace ZoomMap.Domain.Common.Validation.ValidationMediators
{
    public class NeighbourhoodValidationMediator
    {
        private readonly ValidationMediator<Neighbourhood> _validationMediator;

        private NeighbourhoodValidationMediator(ValidationMediator<Neighbourhood> validationMediator)
        {
            _validationMediator = validationMediator;
        }

        public static NeighbourhoodValidationMediator Create()
        {
            ValidationMediator<Neighbourhood> validationMediator = new ValidationMediator<Neighbourhood>(
                new List<IValidationRule<Neighbourhood>>
                {
                    new NotEmptyValidationRule<Neighbourhood>(
                        x => x.Name , Error.Validation(
                            "Neighbourhood.NotEmptyName", 
                            "The neighbourhood name can be empty"
                        )
                    )
                }    
            );

            return new NeighbourhoodValidationMediator(validationMediator);
        }

        public Result<Neighbourhood> Validate(Neighbourhood entity)
        {
            return _validationMediator.Validate(entity);
        }
    }
}
