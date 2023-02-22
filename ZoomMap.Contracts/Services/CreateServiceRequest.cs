namespace ZoomMap.Contracts.Services
{
    public record CreateServiceRequest
    (
        string Name,
        double ServicePrice,
        List<ServiceProductType> ServiceProducts
    );
}
