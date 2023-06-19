using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractDeleteRepository<T> where T : class
    {
        Task<Result<T>> Delete(int id);
    }
}
