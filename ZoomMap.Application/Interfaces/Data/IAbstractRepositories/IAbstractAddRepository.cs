using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractAddRepository<T> where T : class
    {
        Task<Result<T>> Add(T entity);
    }
}
