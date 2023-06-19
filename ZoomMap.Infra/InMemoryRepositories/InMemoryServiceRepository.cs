using System.Linq.Expressions;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Interfaces.Data.IAbstractRepositories;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ServiceEntity;

namespace ZoomMap.Infra.InMemoryRepositories
{
    public class InMemoryServiceRepository : IServiceRepository
    {
        private static readonly List<Service> _services = new();
        public async Task<Result<bool>> Add(Service entity)
        {
            _services.Add(entity);

            return await Task.FromResult(Result<bool>.Ok(true));
            throw new NotImplementedException();
        }

        public Task<Result<List<Service>>> Filter(Expression<Func<Service, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Service>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(Service entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Service>> IAbstractAddRepository<Service>.Add(Service entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Service>> IAbstractUpdateRepository<Service>.Update(Service entity)
        {
            throw new NotImplementedException();
        }
    }
}
