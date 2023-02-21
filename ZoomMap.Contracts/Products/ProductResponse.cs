namespace ZoomMap.Contracts.Products
{
    public record ProductResponse
    (
        Guid ProductId,
        string Name,
        double Price
    );
    
}
