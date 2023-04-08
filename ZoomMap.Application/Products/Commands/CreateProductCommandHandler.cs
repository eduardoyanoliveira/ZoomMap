using MediatR;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Products.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Entities.ProductEntity;

namespace ZoomMap.Application.Products.Commands
{
    public class RegisterCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductResult>>
    {
        private readonly IProductRepository _productRepository;

        public RegisterCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductResult>> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var getProductByNameResult = await _productRepository.GetByName(request.Name);

            if (getProductByNameResult.IsSuccess)
            {
                return Result<ProductResult>.Fail(Errors.Product.NotUniqueProductName);
            }

            Result<Product> productCreationResult = Product.Create(
                request.Name,
                request.Price
            );

            if (productCreationResult.IsFailure)
            {
                return Result<ProductResult>.Fail(productCreationResult.Error);
            }

            Product product = productCreationResult.GetValue();

            Result<bool> persistProductResult = await _productRepository.Add(product);

            if (persistProductResult.IsFailure)
            {
                return Result<ProductResult>.Fail(
                    Errors.Database.InsertError
                );
            }

            ProductResult result = new ProductResult(product);

            return Result<ProductResult>.Ok(result);
        }
    }
}
