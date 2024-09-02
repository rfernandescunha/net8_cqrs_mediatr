using Gertec.Application.Common.Commands;
using Gertec.Application.Produto.Common;

namespace Gertec.Application.Product.Commands.CreateProductCommand
{
    public class CreateProductResponse : CreateResponseBase<ProductResponse>
    {
        public CreateProductResponse(
            IEnumerable<ProductResponse> result, IEnumerable<string> messages)
                : base(result, messages)
        {
        }
    }
}