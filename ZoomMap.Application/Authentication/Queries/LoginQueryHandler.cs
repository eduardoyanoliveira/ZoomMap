using MediatR;
using ZoomMap.Application.Authentication.Common;
using ZoomMap.Application.Interfaces.Authentication;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Validation.Base;
using ZoomMap.Domain.Validation.Errors;

namespace ZoomMap.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByEmail(request.Email);

            if (user == null)
            {
                return Result<AuthenticationResult>.
                    Fail(Errors.Authentication.InvalidCredentials);
            }

            if (user.Password != request.Password)
            {
                return Result<AuthenticationResult>.
                    Fail(Errors.Authentication.InvalidCredentials);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            var result = new AuthenticationResult(user, token);

            return Result<AuthenticationResult>.Ok(result);
        }
    }
}
