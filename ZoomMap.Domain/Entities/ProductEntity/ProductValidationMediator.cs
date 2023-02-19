using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;
using ZoomMap.Domain.Common.Validation.GenericValidationRules;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Domain.Entities.ProductEntity
{
    public class ProductValidationMediator : IValidationMediator<Product>
    {
        private readonly ValidationMediator<Product> _validationMediator;

        private ProductValidationMediator(ValidationMediator<Product> mediator)
        {
            _validationMediator = mediator;
        }

        public static ProductValidationMediator Create()
        {
            ValidationMediator<Product> mediator = new ValidationMediator<Product>(
                new List<IValidationRule<Product>>
                {
                    new NotEmptyValidationRule<Product>(
                       x => x.Name, Errors.Product.EmptyOrNullProductName
                    ),
                    new GreaterThanZeroValidationRule<Product>(
                        x => x.Price, Errors.Product.NotGreaterThanZeroPrice
                    )
                }
            );

            return new ProductValidationMediator(mediator);
        }

        public Result<Product> ValidateBatch(Product entity)
        {
            return _validationMediator.ValidateBatch(entity);
        }
    }
}
