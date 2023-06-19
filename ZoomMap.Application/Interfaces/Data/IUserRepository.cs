using ZoomMap.Application.Interfaces.Data.IAbstractRepositories;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IUserRepository : 
        IAbstractGetRepository<User>, 
        IAbstractUpdateRepository<User>, 
        IAbstractAddRepository<User>
    {
        Task<Result<User>> GetUserByEmail(string email);
    }
}
