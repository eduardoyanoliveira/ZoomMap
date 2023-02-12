using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.ValidationBase
{
    public class ValidationMediator<T>
    {
        private readonly  IEnumerable<IValidationRule<T>> _validations;

        public ValidationMediator(IEnumerable<IValidationRule<T>> validations)
        {
            _validations = validations;
        }

        public Result<T> Validate(T entity)
        {
            foreach (var validation in _validations)
            {
                var result = validation.Validate(entity);
                if (result.IsFailure)
                {
                    return result;
                }
            }

            return Result<T>.Ok(entity);
        }
    }
}
