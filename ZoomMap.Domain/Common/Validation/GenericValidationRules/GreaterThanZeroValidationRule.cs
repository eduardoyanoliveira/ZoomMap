using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.Validation.GenericValidationRules
{
    public class GreaterThanZeroValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, int> _selector;
        private readonly Error _error;

        public GreaterThanZeroValidationRule(Func<T, int> selector, Error error)
        {
            _selector = selector;
            _error = error;
        }

        public Result<T> Validate(T entity)
        {
            if (_selector(entity) <= 0)
            {
                return Result<T>.Fail(_error);
            }

            return Result<T>.Ok();
        }
    }
}
