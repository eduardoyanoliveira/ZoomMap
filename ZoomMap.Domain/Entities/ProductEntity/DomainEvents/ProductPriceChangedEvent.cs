using ZoomMap.Domain.Common.Events;

namespace ZoomMap.Domain.Entities.ProductEntity.DomainEvents
{
    public class ProductPriceChangedEvent: IEvent
    {
        public Guid ProductId { get; }
        public double Price { get; }
        public string Name => "ProductPriceChangedEvent";
        public DateTime OccurredOn => DateTime.Now;

        public ProductPriceChangedEvent(
            Guid productId,
            double price
        )
        {
            ProductId = productId; 
            Price = price;
        }
    }
}
