using MediatR;
using ZoomMap.Application.Authentication.Common;
using ZoomMap.Domain.Common.Validation.Base;

namespace ZoomMap.Application.Authentication.Commands
{
    public record RegisterCommand
    (
        string Username,
        string Email,
        string Password
    ) : IRequest<Result<AuthenticationResult>>;
}
