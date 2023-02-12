using MediatR;
using ZoomMap.Application.Authentication.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Authentication.Queries
{
    public record LoginQuery
    (
        string Email,
        string Password

    ): IRequest<Result<AuthenticationResult>>;
}
