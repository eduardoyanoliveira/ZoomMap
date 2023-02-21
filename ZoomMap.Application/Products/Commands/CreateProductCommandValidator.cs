using FluentValidation;

namespace ZoomMap.Application.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).LessThanOrEqualTo(0);
        }
    }
}
