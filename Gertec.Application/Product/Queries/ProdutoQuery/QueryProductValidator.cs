using FluentValidation;
using Gertec.Application.Product.Queries.ProdutoQuery;

namespace XP.Customers.CustomerFlags.Application.CustomerFlags.Queries.CustomerFlagQuery
{
    public class QueryProdutoValidator : AbstractValidator<QueryProductRequest>
    {
        public QueryProdutoValidator()
        {
        }
    }
}