using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Interfaces.Events;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity.DomainEvents;
using ZoomMap.Domain.Entities.ServiceEntity;

namespace ZoomMap.Application.Events.DomainEventHandlers.ServiceHandlers
{
    public class ServiceHandlerProductPriceChangedEvent : IHandler<ProductPriceChangedEvent>
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceHandlerProductPriceChangedEvent(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Result<string>> Handle(ProductPriceChangedEvent domainEvent)
        {
            Result<List<Service>> serviceFilteringResult = await _serviceRepository.Filter(
               s => s.ServiceProducts.Any(sp => sp.ProductId.Value == domainEvent.ProductId)
            );

            if(serviceFilteringResult.IsFailure)
            {
                return Result<string>.Fail(serviceFilteringResult.Error);
            }

            List<Service> services = serviceFilteringResult.GetValue();
            foreach( Service service in services )
            {
                service.CalculateTotalPrice();
                Result<Service> updateServiceResult =  await _serviceRepository.Update(service);
                if(updateServiceResult.IsFailure) 
                {
                    return Result<string>.Fail(updateServiceResult.Error);
                }
            }

            return Result<string>.Ok("");
        }
    }
}
