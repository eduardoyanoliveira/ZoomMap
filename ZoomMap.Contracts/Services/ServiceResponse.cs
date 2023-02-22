namespace ZoomMap.Contracts.Services
{
    public record ServiceResponse
    (
        string Id,
        string Name,
        List<ServiceProductType> ServiceProducts
    );
}
