using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractGetRepository<T> where T : class   
    {
        Task<Result<T>> Get(string id);
    }
}
