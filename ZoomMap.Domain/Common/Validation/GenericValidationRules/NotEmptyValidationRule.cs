using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.Validation.GenericValidationRules
{
    public class NotEmptyValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, string> _selector;
        private readonly Error _error;

        public NotEmptyValidationRule(Func<T, string> selector, Error error)
        {
            _selector = selector;
            _error = error;
        }

        public Result<T> Validate(T entity)
        {
            if (string.IsNullOrWhiteSpace(_selector(entity)))
            {
                return Result<T>.Fail(_error);
            }

            return Result<T>.Ok();
        }
    }
}
