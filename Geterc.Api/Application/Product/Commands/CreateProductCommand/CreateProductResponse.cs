using Gertec.Api.Application.Common.Commands;
using Gertec.Api.Application.Product.Common;

namespace Gertec.Api.Application.Product.Commands.CreateProductCommand
{
    public class CreateProductResponse : CreateResponseBase<ProductResponse>
    {
        public CreateProductResponse(IEnumerable<ProductResponse> result, IEnumerable<string> messages) : base(result, messages)
        {
        }
    }
}