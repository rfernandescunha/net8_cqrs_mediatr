using FluentValidation;
using Gertec.Api.Application.Product.Queries.QueryProduct.Request;

namespace Gertec.Api.Application.Product.Queries.QueryProduct
{
    public class QueryProdutoValidator : AbstractValidator<QueryProductAllRequest>
    {
        public QueryProdutoValidator()
        {
        }
    }
}