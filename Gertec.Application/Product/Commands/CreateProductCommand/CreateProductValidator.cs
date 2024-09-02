using FluentValidation;

namespace Gertec.Application.Product.Commands.CreateProductCommand
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(r => r.ProductName)
                .NotNull()
                .WithMessage("{ProductName} cannot be null!")
                .NotEmpty()
                .WithMessage("{ProductName} cannot be empty!")
                .MaximumLength(100)
                .WithMessage("{ProductName} has maximum length of 100 characters!");
        }
    }
}