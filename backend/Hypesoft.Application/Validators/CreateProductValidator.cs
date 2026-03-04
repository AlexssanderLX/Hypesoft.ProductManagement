using FluentValidation;
using Hypesoft.Application.Commands.Products;

namespace Hypesoft.Application.Validators
{
    public class CreateProductValidator
        : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(150);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.CategoryId)
                .NotEqual(Guid.Empty);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}