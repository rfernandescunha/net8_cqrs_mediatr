using MediatR;

namespace Gertec.Application.Product.Queries.ProdutoQuery
{
    public class QueryProductRequest : IRequest<QueryProductResponse>
    {
        public int? ProductId { get; set; }

        public string ProductName { get; set; }
    }
}