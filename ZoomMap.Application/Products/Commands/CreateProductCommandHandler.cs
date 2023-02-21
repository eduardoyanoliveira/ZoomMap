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
            if (_productRepository.GetByName(request.Name).IsSuccess)
            {
                return Result<ProductResult>.Fail(Errors.Product.NotUniqueProductName);
            }

            Product product = Product.Create(
                request.Name,
                request.Price
            );

            var persistProductResult = _productRepository.Add(product);

            if (persistProductResult.IsFailure)
            {
                return Result<ProductResult>.Fail(
                    Errors.Database.InsertError
                );
            }

            var result = new ProductResult(product);

            return Result<ProductResult>.Ok(result);
        }
    }
}
