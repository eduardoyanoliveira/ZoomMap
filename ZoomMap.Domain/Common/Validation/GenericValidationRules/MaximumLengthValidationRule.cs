using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.Validation.GenericValidationRules
{
    public class MaximumLengthValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, string> _selector;
        private readonly int _maxLength;
        private readonly Error _error;

        public MaximumLengthValidationRule(Func<T, string> selector, int maxLength, Error error)
        {
            _selector = selector;
            _maxLength = maxLength;
            _error = error;
        }

        public Result<T> Validate(T entity)
        {
            if (_selector(entity).Length > _maxLength)
            {
                return Result<T>.Fail(_error);
            }

            return Result<T>.Ok();
        }
    }
}
