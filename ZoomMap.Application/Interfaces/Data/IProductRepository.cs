using ZoomMap.Application.Interfaces.Data.IAbstractRepositories;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity;

namespace ZoomMap.Application.Interfaces.Data
{
    public interface IProductRepository : 
        IAbstractGetRepository<Product>, 
        IAbstractUpdateRepository<Product>, 
        IAbstractAddRepository<Product>
    {
        Task<Result<Product>> GetByName(string name);
    }
}
