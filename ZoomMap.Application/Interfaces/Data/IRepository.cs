using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IRepository<T>
    {
        Result<T> GetById(Guid id);
        Result<bool> Update(T entity);
        Result<bool> Add(T entity);
    }
}
