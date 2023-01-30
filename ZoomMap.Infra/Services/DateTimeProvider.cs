using ZoomMap.Application.Interfaces.Services;

namespace ZoomMap.Infra.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}