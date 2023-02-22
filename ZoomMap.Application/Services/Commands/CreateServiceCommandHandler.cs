using MediatR;

using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Services.Common;
using ZoomMap.Domain.Common.Models;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ProductEntity.ValueObjects;
using ZoomMap.Domain.Entities.ServiceEntity;
using ZoomMap.Domain.Entities.ServiceEntity.ValueObjects;

namespace ZoomMap.Application.Services.Commands
{
    public class CreateServiceCommandHandler :
        IRequestHandler<CreateServiceCommand, Result<ServiceResult>>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Result<ServiceResult>> Handle(
            CreateServiceCommand request, CancellationToken cancellationToken
        )
        {
            var serviceProducts = request.ServiceProducts.ConvertAll(
                s => ServiceProduct.Create(
                    ValueObjectUtils.FromString<ProductId>(s.ProductId)
                    , s.Price
                    , s.Quantity
                )
            );

            Service service = Service.Create(
                request.Name,
                serviceProducts,
                request.ServicePrice
            );


            var persistUserReulst = await _serviceRepository.Add(service);

            if (persistUserReulst.IsFailure)
            {
                return Result<ServiceResult>.Fail(Errors.Database.InsertError);
            }

            var result = new ServiceResult(service);

            return Result<ServiceResult>.Ok(result);
        }
    }
}
