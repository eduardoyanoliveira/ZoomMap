using System.Text.RegularExpressions;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.ValidationBase;

namespace ZoomMap.Domain.Common.Validation.GenericValidationRules
{
    public class RegularExpressionValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, string> _selector;
        private readonly string _pattern;
        private readonly Error _error;

        public RegularExpressionValidationRule(Func<T, string> selector, string pattern, Error error)
        {
            _selector = selector;
            _pattern = pattern;
            _error = error;
        }

        public Result<T> Validate(T entity)
        {
            if (!Regex.IsMatch(_selector(entity), _pattern))
            {
                return Result<T>.Fail(_error);
            }

            return Result<T>.Ok();
        }
    }
}
