using Gertec.Api.Application.Product.Queries.QueryProduct.Response;
using MediatR;

namespace Gertec.Api.Application.Product.Queries.QueryProduct.Request
{
    public class QueryProductAmountByIdRequest : IRequest<QueryProductAmountByIdResponse>
    {
        public int ProductId { get; set; }
    }
}