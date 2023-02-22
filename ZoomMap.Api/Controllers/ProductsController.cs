﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZoomMap.Application.Products.Commands;
using ZoomMap.Contracts.Products;

namespace ZoomMap.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ProductsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var command = _mapper.Map<CreateProductCommand>(request);

            var result = await _mediator.Send(command);

            if (result.IsFailure) return Problem(result.Error);

            return Ok(
                _mapper.Map<ProductResponse>(result.GetValue())
            );
        }

    }
}
