using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IUserRepository : IRepository<User>
    {
        Result<User> GetUserByEmail(string email);
    }
}
