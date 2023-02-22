using MediatR;
using ZoomMap.Application.Services.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Services.Commands
{
    public record CreateServiceCommand
    (
        string Id,
        string Name,
        double ServicePrice,
        List<ServiceProductType> ServiceProducts
    ) : IRequest<Result<ServiceResult>>;
}
