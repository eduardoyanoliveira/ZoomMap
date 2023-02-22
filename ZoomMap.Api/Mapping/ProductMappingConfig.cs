using Mapster;
using ZoomMap.Application.Products.Commands;
using ZoomMap.Application.Products.Common;
using ZoomMap.Contracts.Products;

namespace ZoomMap.Api.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProductRequest, CreateProductCommand>();

            config.NewConfig<ProductResult, ProductResponse>()
                .Map(dest => dest.Id, src => src.Product.Id.Value)
                .Map(dest => dest, src => src.Product);
        }

    }
}
