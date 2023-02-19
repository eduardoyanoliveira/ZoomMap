using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Common.ValueObjects.CityValueObject
{
    public class CityValidationMediator : IValidationMediator<City>
    {
        private readonly ValidationMediator<City> _validationMediator;

        private CityValidationMediator(ValidationMediator<City> validationMediator)
        {
            _validationMediator = validationMediator;
        }

        public static CityValidationMediator Create()
        {
            ValidationMediator<City> validationMediator = new ValidationMediator<City>(
                new List<IValidationRule<City>>
                {
                    new NotEmptyValidationRule<City>(
                        x => x.Name , Errors.City.NotEmptyName
                    )
                }
            );

            return new CityValidationMediator(validationMediator);
        }

        public Result<City> ValidateBatch(City entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
