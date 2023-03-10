using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Result<Product>> GetByName(string name);
    }
}
