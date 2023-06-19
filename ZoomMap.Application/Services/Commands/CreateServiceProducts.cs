using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Services.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Application.Services.Commands
{
    public class CreateServiceProducts
    {
        private readonly IProductRepository _productRepository;

        public CreateServiceProducts(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<ServiceProduct>>> Execute(IList<ServiceProductType> serviceProductRequests)
        {
            var serviceProducts = new List<ServiceProduct>();

            foreach (var serviceProductRequest in serviceProductRequests)
            {
                var productResult = await _productRepository.Get(serviceProductRequest.ProductId);
                if (productResult.IsFailure) return Result<List<ServiceProduct>>.Fail(productResult.Error);

                var serviceProductResult = ServiceProduct.Create(
                    productResult.GetValue() ,
                    serviceProductRequest.Price, 
                    serviceProductRequest.Quantity
                );

                if (serviceProductResult.IsFailure) return Result<List<ServiceProduct>>.Fail(
                    serviceProductResult.Error
                );

                serviceProducts.Add(serviceProductResult.GetValue());
            }

            return Result<List<ServiceProduct>>.Ok(serviceProducts);
        }
    }
}
