using MediatR;
using ZoomMap.Application.Products.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Products.Commands
{
    public record UpdateProductCommand
    (
        string Id,
        string Name,
        double Price
    ) : IRequest<Result<ProductResult>>;
}
