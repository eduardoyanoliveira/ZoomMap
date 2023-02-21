using MediatR;
using ZoomMap.Application.Products.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Products.Commands
{ 
    public record CreateProductCommand
    (
        string Name,
        double Price
    ) : IRequest<Result<ProductResult>>;
}
