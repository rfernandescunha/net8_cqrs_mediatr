using Gertec.Api.Application.Product.Common;

namespace Gertec.Api.Application.Product.Queries.QueryProduct.Response
{
    public class QueryProductAmountByIdResponse
    {
        public IEnumerable<ProductAmountByIdResponse> Result { get; protected set; }
        public IEnumerable<string> Messages { get; set; }
        public QueryProductAmountByIdResponse(IEnumerable<ProductAmountByIdResponse> result, IEnumerable<string> messages)
        {
            if (messages != null && messages.Any())
            {
                Messages = messages;
            }
            else
            {
                Result = result;

                Messages = Enumerable.Empty<string>();
            }
        }
    }



}

