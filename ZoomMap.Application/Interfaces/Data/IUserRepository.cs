using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Result<User>> GetUserByEmail(string email);
    }
}
