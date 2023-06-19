using System.Linq.Expressions;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Interfaces.Data.IAbstractRepositories
{
    public interface IAbstractFilterRepository<T> where T : class
    {
        Task<Result<List<T>>> Filter(Expression<Func<T, bool>> filterExpression);
    }
}