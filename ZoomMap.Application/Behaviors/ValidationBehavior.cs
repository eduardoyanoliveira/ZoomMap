using FluentValidation;
using MediatR;
using ZoomMap.Domain.Common.Validation.ErrorBase;

namespace ZoomMap.Application.Behaviors
{

    public class ValidationBehavior<TRequest, TResponse>
   : IPipelineBehavior<TRequest, TResponse>
   where TRequest : IRequest<TResponse>
   where TResponse : IError
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            if (_validator != null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(failure => Error.Validation(failure.PropertyName, failure.ErrorMessage));

            return (dynamic)errors;
        }
    }

}
