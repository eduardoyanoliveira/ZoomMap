using MediatR;
using ZoomMap.Application.Authentication.Common;
using ZoomMap.Application.Interfaces.Authentication;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Domain.Common.Validation.ErrorBase;
using ZoomMap.Domain.UserAggregate;
using ZoomMap.Domain.Common.Validation.Errors;

namespace ZoomMap.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var getUserByEmailResult = await _userRepository.GetUserByEmail(request.Email);
            if (getUserByEmailResult.IsSuccess)
            {
                return Result<AuthenticationResult>.Fail(Errors.User.DuplicatedEmail);
            }

            User user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };

            var persistUserReulst = await _userRepository.Add(user);

            if (persistUserReulst.IsFailure)
            {
                return Result<AuthenticationResult>.Fail(Errors.Database.InsertError);
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            var result = new AuthenticationResult(user, token);

            return Result<AuthenticationResult>.Ok(result);
        }
    }
}
