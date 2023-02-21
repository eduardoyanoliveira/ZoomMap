using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Infra.InMemoryRepositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public Result<bool> Add(User user)
        {
            _users.Add(user);

            return Result<bool>.Ok(true);
        }


        public Result<User> GetUserByEmail(string email)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);

            if (user is null)
            {
                return Result<User>.Fail(Errors.Database.RegisterNotFound);
            }

            return Result<User>.Ok(user);
        }


        public Result<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Result<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
