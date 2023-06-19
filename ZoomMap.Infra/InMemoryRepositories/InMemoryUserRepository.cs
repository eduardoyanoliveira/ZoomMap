using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;
using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Application.Interfaces.Data.IAbstractRepositories;

namespace ZoomMap.Infra.InMemoryRepositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public async Task<Result<bool>> Add(User user)
        {
            _users.Add(user);

            return await Task.FromResult(Result<bool>.Ok(true));
        }


        public async Task<Result<User>> GetUserByEmail(string email)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);

            if (user is null)
            {
                return await Task.FromResult(Result<User>.Fail(Errors.Database.RegisterNotFound));
            }

            return await Task.FromResult(Result<User>.Ok(user));
        }


        public async Task<Result<User>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<User>> Get(string id)
        {
            throw new NotImplementedException();
        }

        Task<Result<User>> IAbstractUpdateRepository<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<User>> IAbstractAddRepository<User>.Add(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
