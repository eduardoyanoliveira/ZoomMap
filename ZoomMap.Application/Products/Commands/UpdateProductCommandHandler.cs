using MediatR;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Interfaces.Events;
using ZoomMap.Application.Products.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Domain.Entities.ProductEntity;
using ZoomMap.Domain.Entities.ProductEntity.DomainEvents;

namespace ZoomMap.Application.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMessageBroker _messageBroker;
        public UpdateProductCommandHandler(
            IProductRepository productRepository, 
            IMessageBroker messageBroker
        )
        {
            _productRepository = productRepository;
            _messageBroker = messageBroker;
        }

        public async Task<Result<ProductResult>> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            // Duplicated Validation with Create and Update
            var getProductByNameResult = await _productRepository.GetByName(request.Name);

            if (getProductByNameResult.IsSuccess)
            {
                return Result<ProductResult>.Fail(Errors.Product.NotUniqueProductName);
            }


            Result<Product> productCreationResult = Product.Create(
                request.Id,
                request.Name,
                request.Price
            );

            if (productCreationResult.IsFailure)
            {
                return Result<ProductResult>.Fail(productCreationResult.Error);
            }

            Product product = productCreationResult.GetValue();

            Result<Product> persistProductResult = await _productRepository.Update(product);

            if (persistProductResult.IsFailure)
            {
                return Result<ProductResult>.Fail(
                    Errors.Database.InsertError
                );
            }

            _messageBroker.Publish(new ProductPriceChangedEvent(product.Id.Value, product.Price));

            ProductResult result = new ProductResult(product);

            return Result<ProductResult>.Ok(result);
        }
    }
}
