using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IRepository<T>
    {
        Task<Result<T>> GetById(Guid id);
        Task<Result<bool>> Update(T entity);
        Task<Result<bool>> Add(T entity);
    }
}
