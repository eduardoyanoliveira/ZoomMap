using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
