using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZoomMap.Application.Authentication.Commands;
using ZoomMap.Application.Products.Commands;
using ZoomMap.Contracts.Authentication;
using ZoomMap.Contracts.Products;

namespace ZoomMap.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ApiController
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var command = new CreateProductCommand(
                request.Name,
                request.Price
            );

            var result = await _mediator.Send(command);

            if (result.IsFailure) return Problem(result.Error);

            return Ok(result.GetValue());
        }

    }
}
