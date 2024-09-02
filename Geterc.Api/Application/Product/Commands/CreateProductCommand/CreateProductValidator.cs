using FluentValidation;

namespace Gertec.Api.Application.Product.Commands.CreateProductCommand
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

            RuleFor(r => r.ProductPrice)
                .NotNull()
                .WithMessage("{ProductPrice} cannot be null!")
                .GreaterThan(0)
                .WithMessage("{ProductPrice} cannot be 0!");


            RuleFor(r => r.ProductDescription)
                .NotNull()
                .WithMessage("{ProductDescription} cannot be null!")
                .NotEmpty()
                .WithMessage("{ProductDescription} cannot be empty!")
                .MaximumLength(500)
                .WithMessage("{ProductDescription} has maximum length of 500 characters!");


            RuleFor(r => r.ProductImgUrl)
                .NotNull()
                .WithMessage("{ProductImgUrl} cannot be null!")
                .NotEmpty()
                .WithMessage("{ProductImgUrl} cannot be empty!")
                .MaximumLength(300)
                .WithMessage("{ProductImgUrl} has maximum length of 300 characters!");


            RuleFor(r => r.ProductAmount)
                .NotNull()
                .WithMessage("{ProductAmount} cannot be null!")
                .GreaterThan(0)
                .WithMessage("{ProductAmount} cannot be 0!");
        }
    }
}