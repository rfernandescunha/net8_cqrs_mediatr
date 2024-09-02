using MediatR;

namespace Gertec.Api.Application.Product.Commands.DeleteProductCommand
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; set; }
    }
}