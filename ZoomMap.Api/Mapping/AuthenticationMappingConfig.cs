using Mapster;
using ZoomMap.Application.Authentication.Commands;
using ZoomMap.Application.Authentication.Common;
using ZoomMap.Application.Authentication.Queries;
using ZoomMap.Contracts.Authentication;

namespace ZoomMap.Api.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
