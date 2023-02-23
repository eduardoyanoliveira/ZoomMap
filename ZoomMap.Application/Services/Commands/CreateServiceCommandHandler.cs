using MediatR;

using ZoomMap.Domain.Common.Validation.Errors;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Services.Common;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.Entities.ServiceEntity;


namespace ZoomMap.Application.Services.Commands
{
    public class CreateServiceCommandHandler :
        IRequestHandler<CreateServiceCommand, Result<ServiceResult>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IProductRepository _productRepository;
        public CreateServiceCommandHandler(IServiceRepository serviceRepository, IProductRepository productRepository)
        {
            _serviceRepository = serviceRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<ServiceResult>> Handle(
            CreateServiceCommand request, CancellationToken cancellationToken
        )
        {
            var createServiceProducts = new CreateServiceProducts(_productRepository);
            var serviceProductsResult = await createServiceProducts.Execute(request.ServiceProducts);
            if (serviceProductsResult.IsFailure)
            {
                return Result<ServiceResult>.Fail(serviceProductsResult.Error);
            }

            var service = Service.Create(
                request.Name,
                serviceProductsResult.GetValue(),
                request.ServicePrice);


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
