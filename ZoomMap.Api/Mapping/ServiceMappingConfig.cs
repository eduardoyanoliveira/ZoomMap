using Mapster;
using ZoomMap.Application.Products.Commands;
using ZoomMap.Application.Products.Common;
using ZoomMap.Application.Services.Commands;
using ZoomMap.Application.Services.Common;
using ZoomMap.Contracts.Services;

namespace ZoomMap.Api.Mapping
{
    public class ServiceMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateServiceRequest, CreateServiceCommand>();

            config.NewConfig<ServiceResult, ServiceResponse>()
                .Map(dest => dest, src => src.Service);
        }
    }
}
