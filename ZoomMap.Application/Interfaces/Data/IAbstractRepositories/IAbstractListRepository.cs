using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractListRepository<T> where T : class
    {
        Task<Result<List<T>>> List();
    }
}
