using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZoomMap.Application.Services.Commands;
using ZoomMap.Contracts.Services;

namespace ZoomMap.Api.Controllers
{
    [ApiController]
    [Route("services")]
    public class ServicesController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public ServicesController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateServiceRequest request)
        {
            var command = _mapper.Map<CreateServiceCommand>(request);

            var result = await _mediator.Send(command);

            if (result.IsFailure) return Problem(result.Error);

            return Ok(
                _mapper.Map<ServiceResponse>(result.GetValue())
            );
        }
    }
}
