using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractUpdateRepository<T> where T : class
    {
        Task<Result<T>> Update(T entity);
    }
}
