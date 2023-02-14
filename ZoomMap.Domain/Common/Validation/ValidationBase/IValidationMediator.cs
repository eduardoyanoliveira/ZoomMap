using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Domain.Common.Validation.ValidationBase
{
    public interface IValidationMediator<T>
    {
        Result<T> ValidateBatch(T entity);
    }
}
