using Gertec.Api.Application.Common.Queries;
using Gertec.Api.Application.Product.Common;

namespace Gertec.Api.Application.Product.Queries.QueryProduct.Response
{
    public class QueryProductResponse : QueryResponseBase<ProductResponse>
    {
        public QueryProductResponse(IEnumerable<ProductResponse> result, int pages, int page, IEnumerable<string> messages) : base(result, pages, page, messages)
        {
        }
    }
}