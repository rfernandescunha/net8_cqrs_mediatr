using MediatR;

namespace Gertec.Application.Product.Commands.DeleteProductCommand
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }
}