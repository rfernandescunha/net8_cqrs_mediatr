using FluentValidation;

namespace Gertec.Api.Application.Product.Commands.DeleteProductCommand
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator()
        {
            RuleFor(r => r.ProductId)
                .NotNull()
                .WithMessage("{ProductId} cannot be null!")
                .GreaterThan(0)
                .WithMessage("{ProductId} cannot be 0!");
        }
    }
}