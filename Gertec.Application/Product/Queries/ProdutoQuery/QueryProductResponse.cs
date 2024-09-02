using Gertec.Application.Common.Queries;
using Gertec.Application.Produto.Common;

namespace Gertec.Application.Product.Queries.ProdutoQuery
{
    public class QueryProductResponse : QueryResponseBase<ProductResponse>
    {
        public QueryProductResponse(
            IEnumerable<ProductResponse> result, int pages, int page, IEnumerable<string> messages)
                : base(result, pages, page, messages)
        {
        }
    }
}