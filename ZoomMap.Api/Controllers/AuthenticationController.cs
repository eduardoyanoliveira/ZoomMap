using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZoomMap.Application.Authentication.Commands;
using ZoomMap.Application.Authentication.Queries;
using ZoomMap.Contracts.Authentication;

namespace ZoomMap.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(
                request.Username,
                request.Email,
                request.Password
            );

            var result = await _mediator.Send(command);

            if (result.IsFailure) return Problem(result.Error);

            return Ok(_mapper.Map<AuthenticationResponse>(result.GetValue()));
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = new LoginQuery(
                request.Email,
                request.Password
            );

            var result = await _mediator.Send(command);

            if (result.IsFailure) return Problem(result.Error);

            return Ok(
                _mapper.Map<AuthenticationResponse>(result.GetValue())
            );
        }
    }
}
