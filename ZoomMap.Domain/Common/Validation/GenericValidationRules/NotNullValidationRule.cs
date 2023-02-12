using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.Validation.GenericValidationRules
{
    public class NotNullValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, object> _selector;
        private readonly Error _error;

        public NotNullValidationRule(Func<T, object> selector, Error error)
        {
            _selector = selector;
            _error = error;
        }

        public Result<T> Validate(T entity)
        {
            if (_selector(entity) == null)
            {
                return Result<T>.Fail(_error);
            }

            return Result<T>.Ok();
        }
    }
}
