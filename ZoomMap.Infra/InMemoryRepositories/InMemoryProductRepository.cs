using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Infra.InMemoryRepositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new();
        public async Task<Result<bool>> Add(Product entity)
        {
            _products.Add(entity);

            return await Task.FromResult(Result<bool>.Ok(true));
        }

        public async Task<Result<Product>> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Product>> GetByName(string name)
        {
            var product = _products.SingleOrDefault(u => u.Name == name);

            if (product is null)
            {
                return await Task.FromResult(Result<Product>.Fail(Errors.Database.RegisterNotFound));
            }

            return await Task.FromResult(Result<Product>.Ok(product));
        }

        public async Task<Result<bool>> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
