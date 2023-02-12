using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.ValidationBase
{
    public interface IValidationRule<T>
    {
        Result<T> Validate(T entity);
    }

}
