using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
