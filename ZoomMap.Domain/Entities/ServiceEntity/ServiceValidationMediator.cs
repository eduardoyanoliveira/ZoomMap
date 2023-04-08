using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Entities.ServiceEntity;

namespace ZoomMap.Domain.Entities.ProductEntity
{
    public class ServiceValidationMediator : IValidationMediator<Service>
    {
        private readonly ValidationMediator<Service> _validationMediator;

        private ServiceValidationMediator(ValidationMediator<Service> mediator)
        {
            _validationMediator = mediator;
        }

        public static ServiceValidationMediator Create()
        {
            ValidationMediator<Service> mediator = new ValidationMediator<Service>(
                new List<IValidationRule<Service>>
                {
                    new NotEmptyValidationRule<Service>(
                       x => x.Name, Errors.Service.EmptyOrNullServiceName
                    ),
                    new GreaterThanZeroValidationRule<Service>(
                        x => x.ServicePrice, Errors.Service.NotGreaterThanZeroPrice
                    )
                }
            );

            return new ServiceValidationMediator(mediator);
        }

        public Result<Service> ValidateBatch(Service entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
