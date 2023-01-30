using ZoomMap.Domain.UserAggregate;

namespace ZoomMap.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}